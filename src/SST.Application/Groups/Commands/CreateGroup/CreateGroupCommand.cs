using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<int>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public bool IsMain { get; set; }
    }
}
