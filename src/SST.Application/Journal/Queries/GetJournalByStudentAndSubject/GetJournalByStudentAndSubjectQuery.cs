using MediatR;

namespace SST.Application.Journal.Queries.GetJournalByStudentAndSubject
{
    public class GetJournalByStudentAndSubjectQuery : IRequest<JournalVm>
    {
        public int StudentId { get; set; }

        public int SubjectId { get; set; }
    }
}
