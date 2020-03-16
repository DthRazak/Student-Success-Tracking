using MediatR;

namespace SST.Application.Lectors.Commands.LinkLectorToUser
{
    public class LinkLectorToUserCommand : IRequest
    {
        public int Id { get; set; }

        public string UserRef { get; set; }
    }
}
