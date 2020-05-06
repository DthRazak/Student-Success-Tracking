using MediatR;

namespace SST.Application.Subjects.Queries.GetSubjectNameByColumnJournal
{
    public class GetSubjectNameByColumnJournalQuery : IRequest<SubjectDto>
    {
        public int JournalColumnId { get; set; }
    }
}
