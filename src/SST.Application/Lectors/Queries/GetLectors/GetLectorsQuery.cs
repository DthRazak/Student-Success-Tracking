using MediatR;

namespace SST.Application.Lectors.Queries.GetLectors
{
    public class GetLectorsQuery : IRequest<LectorsListVm>
    {
    }
}
