using MediatR;

namespace SST.Application.Requests.Commands.DeleteRequest
{
    public class DeleteRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
