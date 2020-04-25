using MediatR;

namespace SST.Application.Subjects.Commands.LinkSubjectToGroup
{
    public class LinkSubjectToGroupCommand : IRequest
    {
        public int SubjectId { get; set; }

        public int GroupId { get; set; }
    }
}
