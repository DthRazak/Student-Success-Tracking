using System;
using MediatR;

namespace SST.Application.Requests.Queries.GetNotApprovedRequests
{
    public class GetNotApprovedRequestsQuery : IRequest<RequestsListVm>
    {
    }
}
