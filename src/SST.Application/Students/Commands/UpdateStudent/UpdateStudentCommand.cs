
using MediatR;

namespace SST.Application.Students.Commands.UpdateStudent
{
    class UpdateStudentCommand : IRequest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Group { get; set; }

        public string UserRef { get; set; }
    }
}
