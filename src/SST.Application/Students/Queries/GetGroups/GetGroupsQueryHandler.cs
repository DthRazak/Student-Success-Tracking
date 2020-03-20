using MediatR;
using SST.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Students.Queries.GetGroups
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
            var groups = await Task.Run( () => _context.Students
                .GroupBy(x => x.Group)
                .Select(x => x.Key)
                .ToList());

            return new GroupsListVm { Groups = groups };
        }
    }
}
