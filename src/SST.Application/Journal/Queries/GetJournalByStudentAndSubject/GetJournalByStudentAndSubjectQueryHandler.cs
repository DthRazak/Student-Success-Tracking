using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Journal.Queries.GetJournalByStudentAndSubject
{
    public class GetJournalByStudentAndSubjectQueryHandler : IRequestHandler<GetJournalByStudentAndSubjectQuery, JournalVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetJournalByStudentAndSubjectQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JournalVm> Handle(GetJournalByStudentAndSubjectQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

            var studentFullName = student.LastName + " " + student.FirstName;
            var groupSubject = await _context.GroupSubjects
                .Include(gs => gs.Group)
                    .ThenInclude(g => g.Students)
                .FirstAsync(s => s.SubjectRef == request.SubjectId && s.GroupRef == student.GroupRef, cancellationToken);

            var groupStudents = new List<StudentDto>();
            foreach (var st in groupSubject.Group.Students)
            {
                groupStudents.Add(_mapper.Map<StudentDto>(st));
            }

            var journalColumns = await _context.JournalColumns
                .Include(jc => jc.Grades)
                .Where(jc => jc.GroupSubjectRef == groupSubject.Id)
                .ToListAsync(cancellationToken);

            var header = new List<JournalHeaderDto>();
            foreach (var column in journalColumns)
            {
                header.Add(new JournalHeaderDto
                {
                    Date = column.Date,
                    Note = column.Note
                });
            }

            header.Sort();

            var dates = header.Select(x => x.Date).ToList();

            var journal = new SortedList<StudentDto, JournalRowDto>();
            foreach (var st in groupStudents)
            {
                var row = new JournalRowDto(dates);
                foreach (var column in journalColumns)
                {
                    var grade = column.Grades.Where(g => g.StudentRef == st.Id).FirstOrDefault();
                    row.Row[column.Date] = grade != null ? new Tuple<int, int>(grade.Id, grade.Mark) : new Tuple<int, int>(grade != null ? grade.Id : 0, 0);
                    row.Total = row.Row.Values.Sum(x => x.Item2);
                }

                journal.Add(st, row);
            }

            var vm = new JournalVm
            {
                StudentFullName = studentFullName,
                Header = header,
                Journal = journal
            };

            return vm;
        }
    }
}
