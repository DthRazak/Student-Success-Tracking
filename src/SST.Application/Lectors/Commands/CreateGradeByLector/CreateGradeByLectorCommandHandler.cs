using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Lectors.Commands.CreateGradeByLector
{
    public class CreateGradeByLectorCommandHandler : IRequestHandler<CreateGradeByLectorCommand, int>
    {
        private readonly ISSTDbContext _context;

        public CreateGradeByLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGradeByLectorCommand request, CancellationToken cancellationToken)
        {
            var journalColEnt = await _context.JournalColumns
                .FirstOrDefaultAsync(x => x.Id == request.JournalColumnId, cancellationToken);

            if (journalColEnt != null)
            {
                if (journalColEnt.GroupSubject.Subject.LectorRef != request.LectorId)
                {
                    throw new Exception($"Actual LectorId({journalColEnt.GroupSubject.Subject.LectorRef}) isn't compatible with given({request.LectorId}");
                }
            }

            var entity = new Grade
            {
                Mark = request.Mark,
                StudentRef = request.StudentId,
                JournalColumnRef = request.JournalColumnId
            };

            _context.Grades.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
