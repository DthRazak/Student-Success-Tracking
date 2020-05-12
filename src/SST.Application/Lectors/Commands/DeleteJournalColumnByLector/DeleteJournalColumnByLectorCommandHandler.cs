using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

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
                .Include(jc => jc.GroupSubject)
                    .ThenInclude(gs => gs.Subject)
                .FirstOrDefaultAsync(x => x.Id == request.JournalColumnId, cancellationToken);

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
