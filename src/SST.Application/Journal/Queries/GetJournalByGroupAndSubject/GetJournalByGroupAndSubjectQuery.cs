using MediatR;

namespace SST.Application.Journal.Queries.GetJournalByGroupAndSubject
{
    public class GetJournalByGroupAndSubjectQuery : IRequest<JournalVm>
    {
        public int GroupId { get; set; }

        public int SubjectId { get; set; }
    }
}
