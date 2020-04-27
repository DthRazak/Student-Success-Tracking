using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Subjects.Commands.LinkSubjectToGroup
{
    public class LinkSubjectToGroupCommand : IRequest
    {
        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int GroupId { get; set; }
    }
}
