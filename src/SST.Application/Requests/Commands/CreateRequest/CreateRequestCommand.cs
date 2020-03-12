using MediatR;

namespace SST.Application.Requests.Commands.CreateRequest
{
    class CreateRequestCommand : IRequest<int>
    {
        public string UserRef { get; set; }
    }
}
