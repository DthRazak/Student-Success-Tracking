using MediatR;

namespace SST.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommand : IRequest<int>
    {
        public string UserRef { get; set; }
    }
}
