using System.ComponentModel.DataAnnotations;
using MediatR;

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
        public int GroupId { get; set; }

        public string UserRef { get; set; }
    }
}
