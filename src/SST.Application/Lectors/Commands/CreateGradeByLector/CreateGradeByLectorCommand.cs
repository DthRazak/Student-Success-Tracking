using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Lectors.Commands.CreateGradeByLector
{
    public class CreateGradeByLectorCommand : IRequest<int>
    {
        [Required]
        public int Mark { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int JournalColumnId { get; set; }

        public int LectorId { get; set; }
    }
}
