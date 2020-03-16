using SST.Application.Students.Queries.GetGroups;
using SST.Application.Students.Queries.GetStudentsByGroup;
using SST.WebUI.Forms;

namespace SST.WebUI.ViewModels
{
    public class SignupModel
    {
        public GroupsListVm GroupsList { get; set; }

        public StudentsListVm StudentsList { get; set; }

        public StudentSignupForm StudentSignupForm { get; set; }

        public LectorSignupForm LectorSignupForm { get; set; }
    }
}
