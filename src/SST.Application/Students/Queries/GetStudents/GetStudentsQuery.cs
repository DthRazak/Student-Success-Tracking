using MediatR;

namespace SST.Application.Students.Queries.GetStudents
{
    public class GetStudentsQuery : IRequest<StudentsListVm>
    {
    }
}
