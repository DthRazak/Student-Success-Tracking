using System;
using MediatR;

namespace SST.Application.Requests.Queries.GetRequests
{
    public class GetRequestsQuery : IRequest<RequestsListVm>
    {
    }
}
