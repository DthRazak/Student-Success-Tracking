using MediatR;

namespace SST.Application.Students.Commands.DeleteStudent
{
    class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
