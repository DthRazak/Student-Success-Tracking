using MediatR;

namespace SST.Application.Lectors.Commands.UnlinkLector
{
    public class UnlinkLectorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
