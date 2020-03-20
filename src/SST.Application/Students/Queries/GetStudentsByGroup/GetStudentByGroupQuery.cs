using MediatR;

namespace SST.Application.Students.Queries.GetStudentsByGroup
{
    public class GetStudentByGroupQuery : IRequest<StudentsListVm>
    {
        public string Group { get; set; }
    }
}
