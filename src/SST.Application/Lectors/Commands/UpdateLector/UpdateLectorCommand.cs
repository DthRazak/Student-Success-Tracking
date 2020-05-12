using MediatR;

namespace SST.Application.Lectors.Commands.UpdateLector
{
    public class UpdateLectorCommand : IRequest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AcademicStatus { get; set; }

        public string UserRef { get; set; }
    }
}
