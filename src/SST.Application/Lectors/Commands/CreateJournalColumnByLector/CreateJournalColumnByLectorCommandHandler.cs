using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Commands.CreateJournalColumnByLector
{
    public class CreateJournalColumnByLectorCommandHandler : IRequestHandler<CreateJournalColumnByLectorCommand, int>
    {
        private readonly ISSTDbContext _context;

        public CreateJournalColumnByLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateJournalColumnByLectorCommand request, CancellationToken cancellationToken)
        {
            var groupSubjEnt = await _context.GroupSubjects
                .Include(gs => gs.Subject)
                    .ThenInclude(s => s.Lector)
                .FirstOrDefaultAsync(x => x.Id == request.GroupSubjectId, cancellationToken);

            if (groupSubjEnt != null)
            {
                if (groupSubjEnt.Subject.LectorRef != request.LectorId)
                {
                    throw new Exception($"Actual LectorId({groupSubjEnt.Subject.LectorRef}) isn't compatible with given({request.LectorId}");
                }
            }

            var entity = new JournalColumn
            {
                Date = request.Date,
                Note = request.Note,
                GroupSubjectRef = request.GroupSubjectId
            };

            _context.JournalColumns.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
