using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommand : IRequest<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int LectorId { get; set; }
    }
}
