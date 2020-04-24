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
                .Include(s => s.Group)
                .ThenInclude(g => g.GroupSubjects)
                .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

            var studentFullName = student.FirstName + " " + student.LastName;
            var subject = student.Group.GroupSubjects
                .First(s => s.Id == request.SubjectId);

            var journal = new List<JournalColumnDto>();
            foreach (var column in subject.Journal)
            {
                journal.Add(_mapper.Map<JournalColumnDto>(column));
            }

            journal.OrderBy(j => j.Date);

            var totalList = new SortedList<string, int>();

            // TODO: total
            var vm = new JournalVm
            {
                StudentFullName = studentFullName,
                Journal = journal,
                Total = totalList
            };

            return vm;
        }
    }
}
