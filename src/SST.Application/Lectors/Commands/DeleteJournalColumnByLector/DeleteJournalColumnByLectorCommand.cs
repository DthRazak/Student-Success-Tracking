using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Lectors.Commands.DeleteJournalColumnByLector
{
    public class DeleteJournalColumnByLectorCommand : IRequest
    {
        [Required]
        public int JournalColumnId { get; set; }

        public int LectorId { get; set; }
    }
}
