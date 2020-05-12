using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Lectors.Commands.CreateLector
{
    public class CreateLectorCommand : IRequest<int>
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string AcademicStatus { get; set; }

        public string UserRef { get; set; }
    }
}
