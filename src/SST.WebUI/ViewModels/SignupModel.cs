using SST.Application.Students.Queries.GetGroups;
using SST.WebUI.Forms;

namespace SST.WebUI.ViewModels
{
    public class SignupModel
    {
        public GroupsListVm GroupsList { get; set; }

        public SignupForm SignupForm { get; set; }
    }
}
