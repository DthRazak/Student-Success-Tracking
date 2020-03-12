using MediatR;

namespace SST.Application.Users.Commands.CreateUser
{
    class CreateUserCommand : IRequest<string>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
