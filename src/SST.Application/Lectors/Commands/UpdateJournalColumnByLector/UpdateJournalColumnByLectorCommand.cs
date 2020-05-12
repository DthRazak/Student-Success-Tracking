using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Lectors.Commands.UpdateJournalColumnByLector
{
    public class UpdateJournalColumnByLectorCommand : IRequest
    {
        [Required]
        public int JournalColumnId { get; set; }

        public DateTime? Date { get; set; }

        public string Note { get; set; }

        public int? GroupSubjectId { get; set; }

        public int LectorId { get; set; }
    }
}
