using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Grades.Queries.GetGradeInfoByGroupAndSubject
{
    public class GetGradeInfoByGroupAndSubjectQueryHandler : IRequestHandler<GetGradeInfoByGroupAndSubjectQuery, GradesInfoListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetGradeInfoByGroupAndSubjectQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GradesInfoListVm> Handle(GetGradeInfoByGroupAndSubjectQuery request, CancellationToken cancellationToken)
        {
            var gradesInfos = await _context.StudentSubjects
               .Where(x => (x.Student.Group == request.Group) && (x.Subject.Id == request.SubjectId))
               .ProjectTo<GradesInfoDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new GradesInfoListVm { GradesInfos = gradesInfos };
        }
    }
}
