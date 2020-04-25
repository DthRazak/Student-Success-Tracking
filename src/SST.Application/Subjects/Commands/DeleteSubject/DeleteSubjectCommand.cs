using MediatR;

namespace SST.Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
