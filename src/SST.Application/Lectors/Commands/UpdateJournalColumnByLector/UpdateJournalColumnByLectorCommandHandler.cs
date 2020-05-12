using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Commands.UpdateJournalColumnByLector
{
    public class UpdateJournalColumnByLectorCommandHandler : IRequestHandler<UpdateJournalColumnByLectorCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public UpdateJournalColumnByLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateJournalColumnByLectorCommand request, CancellationToken cancellationToken)
        {
            var journalColEnt = await _context.JournalColumns
                .Include(jc => jc.GroupSubject)
                    .ThenInclude(gs => gs.Subject)
                        .ThenInclude(s => s.Lector)
                .FirstOrDefaultAsync(x => x.Id == request.JournalColumnId, cancellationToken);

            if (journalColEnt != null)
            {
                if (journalColEnt.GroupSubject.Subject.LectorRef != request.LectorId)
                {
                    throw new Exception($"Actual LectorId({journalColEnt.GroupSubject.Subject.LectorRef}) isn't compatible with given({request.LectorId}");
                }

                if (request.Date != null)
                {
                    journalColEnt.Date = (DateTime)request.Date;
                }

                if (request.Note != null)
                {
                    journalColEnt.Note = (string)request.Note;
                }

                if (request.GroupSubjectId != null)
                {
                    journalColEnt.GroupSubjectRef = (int)request.GroupSubjectId;
                }

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
