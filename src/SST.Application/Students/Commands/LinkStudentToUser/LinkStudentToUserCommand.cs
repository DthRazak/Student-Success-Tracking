using MediatR;

namespace SST.Application.Students.Commands.LinkStudentToUser
{
    public class LinkStudentToUserCommand : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Group { get; set; }

        public string UserRef { get; set; }
    }
}
