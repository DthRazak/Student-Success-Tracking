using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Grades.Queries.GetGradeInfoByStudentAndSubject
{
    public class GetGradeInfoByStudentAndSubjectQueryHandler : IRequestHandler<GetGradeInfoByStudentAndSubjectQuery, GradesInfoVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetGradeInfoByStudentAndSubjectQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GradesInfoVm> Handle(GetGradeInfoByStudentAndSubjectQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.StudentId);

            var group = student.Group;
            var studentFullName = student.FirstName + " " + student.LastName;

            var studentSubjects = await _context.StudentSubjects
                .Include(ss => ss.Student)
                .Include(ss => ss.Grades)
               .Where(x => (x.Student.Group == group) && (x.SubjectRef == request.SubjectId))
               .ToListAsync(cancellationToken);

            var gradesInfos = new List<GradesInfoDto>();
            foreach (var item in studentSubjects)
            {
                gradesInfos.Add(_mapper.Map<GradesInfoDto>(item));
            }

            var dateSet = new HashSet<DateTime>();
            foreach (var gradesInfo in gradesInfos)
            {
                foreach (var date in gradesInfo.Marks.Keys)
                {
                    dateSet.Add(date);
                }
            }

            var dates = dateSet.ToList();
            dates.Sort();

            var vm = new GradesInfoVm
            {
                StudentFullName = studentFullName,
                Dates = dates,
                GradesInfos = gradesInfos
            };

            return vm;
        }
    }
}
