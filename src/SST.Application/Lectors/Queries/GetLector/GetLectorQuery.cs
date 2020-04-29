using MediatR;

namespace SST.Application.Lectors.Queries.GetLector
{
    public class GetLectorQuery : IRequest<LectorVm>
    {
        public int LectorId { get; set; }
    }
}
