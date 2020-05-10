using MediatR;

namespace SST.Application.Groups.Queries.GetGroupsByFaculty
{
    public class GetGroupsByFacultyQuery : IRequest<GroupsListVm>
    {
        public string Faculty { get; set; }
    }
}
