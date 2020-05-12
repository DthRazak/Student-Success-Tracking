using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Groups.Queries.GetGroups
{
    public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, GroupsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetGroupsQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GroupsListVm> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _context.Groups
               .OrderBy(g => g.Faculty)
               .ThenBy(g => g.Name)
               .ProjectTo<GroupsDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new GroupsListVm { Groups = groups };
        }
    }
}
