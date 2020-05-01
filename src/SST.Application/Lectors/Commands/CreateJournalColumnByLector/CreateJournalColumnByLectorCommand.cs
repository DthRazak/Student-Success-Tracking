using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SST.Application.Lectors.Commands.CreateJournalColumnByLector
{
    public class CreateJournalColumnByLectorCommand : IRequest<int>
    {
        [Required]
        public DateTime Date { get; set; }

        public string Note { get; set; }

        [Required]
        public int GroupSubjectId { get; set; }

        public int LectorId { get; set; }
    }
}
