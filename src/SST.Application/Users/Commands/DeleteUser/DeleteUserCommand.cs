using MediatR;

namespace SST.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string Email { get; set; }
    }
}
