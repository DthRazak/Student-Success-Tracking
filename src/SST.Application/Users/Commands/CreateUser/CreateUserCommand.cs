using MediatR;

namespace SST.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
