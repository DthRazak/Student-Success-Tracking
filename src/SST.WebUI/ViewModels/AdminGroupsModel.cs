using SST.Application.Groups.Queries.GetFaculties;
using SST.Application.Groups.Queries.GetGroups;

namespace SST.WebUI.ViewModels
{
    public class AdminGroupsModel
    {
        public GroupsListVm GroupsList { get; set; }

        public FacultyListVm FacultyList { get; set; }
    }
}
