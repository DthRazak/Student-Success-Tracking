using MediatR;

namespace SST.Application.Lectors.Commands.DeleteLector
{
    public class DeleteLectorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
