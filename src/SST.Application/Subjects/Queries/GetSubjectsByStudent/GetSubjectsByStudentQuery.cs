using MediatR;

namespace SST.Application.Subjects.Queries.GetSubjectsByStudent
{
    public class GetSubjectsByStudentQuery : IRequest<SubjectsListVm>
    {
        public int StudentId { get; set; }
    }
}
