using MediatR;

namespace SST.Application.Students.Queries.GetNotLinkedStudentsByGroup
{
    public class GetNotLinkedStudentsByGroupQuery : IRequest<StudentsListVm>
    {
        public string Group { get; set; }
    }
}
