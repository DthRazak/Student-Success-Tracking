using MediatR;

namespace SST.Application.Users.Commands.UpdateUser
{
    class UpdateUserCommand : IRequest
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool? IsAdmin { get; set; }
    }
}
