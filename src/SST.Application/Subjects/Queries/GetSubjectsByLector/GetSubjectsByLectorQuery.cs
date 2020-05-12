using MediatR;

namespace SST.Application.Subjects.Queries.GetSubjectsByLector
{
    public class GetSubjectsByLectorQuery : IRequest<SubjectsListVm>
    {
        public int LectorId { get; set; }
    }
}
