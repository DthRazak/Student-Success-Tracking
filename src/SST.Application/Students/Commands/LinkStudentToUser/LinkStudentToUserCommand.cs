using MediatR;

namespace SST.Application.Students.Commands.LinkStudentToUser
{
    public class LinkStudentToUserCommand : IRequest
    {
        public int Id { get; set; }

        public string UserRef { get; set; }
    }
}
