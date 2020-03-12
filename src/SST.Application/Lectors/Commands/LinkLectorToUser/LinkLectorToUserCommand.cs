using MediatR;

namespace SST.Application.Lectors.Commands.LinkLectorToUser
{
    class LinkLectorToUserCommand : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserRef { get; set; }
    }
}
