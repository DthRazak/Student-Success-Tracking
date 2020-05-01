using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Lectors.Commands.UpdateGradeByLector
{
    public class UpdateGradeByLectorCommand : IRequest
    {
        [Required]
        public int GradeId { get; set; }

        public int Mark { get; set; }

        public int? StudentId { get; set; }

        public int? JournalColumnId { get; set; }

        public int LectorId { get; set; }
    }
}
