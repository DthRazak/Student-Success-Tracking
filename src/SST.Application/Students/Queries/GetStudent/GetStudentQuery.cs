using MediatR;

namespace SST.Application.Students.Queries.GetStudent
{
    public class GetStudentQuery : IRequest<StudentVm>
    {
        public int StudentId { get; set; }
    }
}
