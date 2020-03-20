using MediatR;

namespace SST.Application.Students.Queries.GetGroups
{
    public class GetGroupsQuery : IRequest<GroupsListVm>
    {
    }
}
