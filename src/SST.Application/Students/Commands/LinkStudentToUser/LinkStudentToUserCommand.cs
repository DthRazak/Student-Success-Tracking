using MediatR;

namespace SST.Application.Students.Commands.LinkStudentToUser
{
    public class LinkStudentToUserCommand : IRequest
    {
        public string FullName { get; set; }

        public string Group { get; set; }

        public string UserRef { get; set; }
    }
}
