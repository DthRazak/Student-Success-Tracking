using MediatR;

namespace SST.Application.Requests.Commands.DeleteRequest
{
    class DeleteRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
