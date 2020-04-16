using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            var group = (await _context.Students.FindAsync(request.StudentId)).Group;

            var gradesInfos = await _context.StudentSubjects
               .Where(x => (x.Student.Group == group) && (x.Subject.Id == request.SubjectId))
               .ProjectTo<GradesInfoDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

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
                Dates = dates,
                GradesInfos = gradesInfos
            };

            return vm;
        }
    }
}
