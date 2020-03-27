using MediatR;

namespace SST.Application.Lectors.Commands.DeleteLector
{
    class DeleteLectorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
