using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Lectors.Commands.DeleteJournalColumnByLector
{
    public class DeleteJournalColumnByLectorCommandHandler : IRequestHandler<DeleteJournalColumnByLectorCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public DeleteJournalColumnByLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteJournalColumnByLectorCommand request, CancellationToken cancellationToken)
        {
            var journalColEnt = await _context.JournalColumns
                .FindAsync(request.JournalColumnId);

            if (journalColEnt != null)
            {
                if (journalColEnt.GroupSubject.Subject.LectorRef != request.LectorId)
                {
                    throw new Exception($"Actual LectorId({journalColEnt.GroupSubject.Subject.LectorRef}) isn't compatible with given({request.LectorId}");
                }

                _context.JournalColumns.Remove(journalColEnt);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            else
            {
                throw new Exception($"JournalColumn with id({request.JournalColumnId}) doesn't exists");
            }
        }
    }
}
