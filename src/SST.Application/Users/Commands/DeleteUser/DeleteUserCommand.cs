using MediatR;

namespace SST.Application.Users.Commands.DeleteUser
{
    class DeleteUserCommand : IRequest
    {
        public string Email { get; set; }
    }
}
