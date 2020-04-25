using MediatR;

namespace SST.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommand : IRequest<int>
    {
        public string Name { get; set; }

        public int LectorId { get; set; }
    }
}
