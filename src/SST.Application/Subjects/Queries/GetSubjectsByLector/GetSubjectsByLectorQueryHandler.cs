using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Subjects.Queries.GetSubjectsByLector
{
    public class GetSubjectsByLectorQueryHandler : IRequestHandler<GetSubjectsByLectorQuery, SubjectsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetSubjectsByLectorQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubjectsListVm> Handle(GetSubjectsByLectorQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _context.Subjects
                .Include(s => s.GroupSubjects)
                .Where(x => x.LectorRef == request.LectorId)
                .ProjectTo<SubjectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach (var subject in subjects)
            {
                var groups = _context.GroupSubjects
                    .Include(gs => gs.Group)
                    .Where(x => x.SubjectRef == subject.Id);

                foreach (var group in groups)
                {
                    subject.Groups.Add(group.Group.Name, group.GroupRef);
                }
            }

            return new SubjectsListVm { Subjects = subjects };
        }
    }
}
