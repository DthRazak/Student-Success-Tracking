using MediatR;

namespace SST.Application.Lectors.Commands.LinkLectorToUser
{
    public class LinkLectorToUserCommand : IRequest
    {
        public string FullName { get; set; }

        public string UserRef { get; set; }
    }
}
