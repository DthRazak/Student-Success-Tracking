using SST.Application.Groups.Queries.GetFaculties;
using SST.WebUI.Forms;

namespace SST.WebUI.ViewModels
{
    public class SignupModel
    {
        public FacultyListVm FacultyList { get; set; }

        public StudentSignupForm StudentSignupForm { get; set; }

        public LectorSignupForm LectorSignupForm { get; set; }
    }
}
