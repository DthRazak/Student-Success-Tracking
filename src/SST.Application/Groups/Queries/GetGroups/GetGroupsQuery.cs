using MediatR;

namespace SST.Application.Groups.Queries.GetGroups
{
    public class GetGroupsQuery : IRequest<GroupsListVm>
    {
    }
}
