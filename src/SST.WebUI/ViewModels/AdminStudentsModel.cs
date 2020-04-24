using SST.Application.Groups.Queries.GetGroups;
using SST.Application.Students.Queries.GetStudents;

namespace SST.WebUI.ViewModels
{
    public class AdminStudentsModel
    {
        public StudentsListVm StudentsList { get; set; }

        public GroupsListVm GroupsList { get; set; }
    }
}
