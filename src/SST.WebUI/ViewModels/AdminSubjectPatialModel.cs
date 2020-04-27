using SST.Application.Groups.Queries.GetGroups;
using SST.Application.Subjects.Queries.GetSubjectsByLector;

namespace SST.WebUI.ViewModels
{
    public class AdminSubjectPatialModel
    {
        public GroupsListVm GroupList { get; set; }

        public SubjectsListVm SubjectsList { get; set; }
    }
}
