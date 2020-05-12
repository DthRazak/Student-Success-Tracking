using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Groups.Queries.GetGroupsByFaculty
{
    public class GroupsDto : IMapFrom<Group>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Faculty { get; set; }
    }
}
