using MediatR;
using System.ComponentModel.DataAnnotations;

namespace SST.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<int>
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Group { get; set; }

        public string UserRef { get; set; }
    }
}
