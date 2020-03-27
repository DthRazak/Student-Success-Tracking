using MediatR;

namespace SST.Application.Lectors.Commands.CreateLector
{
    public class CreateLectorCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AcademicStatus { get; set; }

        public string UserRef { get; set; }
    }
}
