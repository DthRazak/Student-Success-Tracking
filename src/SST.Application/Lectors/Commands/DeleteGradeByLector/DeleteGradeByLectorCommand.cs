using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Lectors.Commands.DeleteGradeByLector
{
    public class DeleteGradeByLectorCommand : IRequest
    {
        [Required]
        public int GradeId { get; set; }

        public int LectorId { get; set; }
    }
}
