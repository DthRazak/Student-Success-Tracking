using MediatR;
using SST.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Groups.Queries.GetGroups
{
    public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, GroupsListVm>
    {
        private readonly ISSTDbContext _context;

        public GetGroupsQueryHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<GroupsListVm> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await Task.Run(() => _context.Groups
               .Select(x => x.Name)
               .ToList());

            return new GroupsListVm { Groups = groups };
        }
    }
}
