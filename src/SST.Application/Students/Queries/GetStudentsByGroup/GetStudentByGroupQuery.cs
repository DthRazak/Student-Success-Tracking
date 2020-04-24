using MediatR;

namespace SST.Application.Students.Queries.GetStudentsByGroup
{
    public class GetStudentByGroupQuery : IRequest<StudentsListVm>
    {
        public int GroupId { get; set; }
    }
}
