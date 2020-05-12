using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Commands.CreateOrUpdateGradeByLector
{
    public class CreateOrUpdateGradeByLectorCommandHandler : IRequestHandler<CreateOrUpdateGradeByLectorCommand, int>
    {
        private readonly ISSTDbContext _context;

        public CreateOrUpdateGradeByLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrUpdateGradeByLectorCommand request, CancellationToken cancellationToken)
        {
            if (request.GradeId == 0)
            {
                // Create command
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
            else
            {
                // Update command
                var gradeEnt = await _context.Grades
                    .Include(g => g.JournalColumn)
                    .ThenInclude(jc => jc.GroupSubject)
                    .ThenInclude(gs => gs.Subject)
                    .ThenInclude(s => s.Lector)
                    .FirstOrDefaultAsync(x => x.Id == request.GradeId, cancellationToken);

                if (gradeEnt != null)
                {
                    if (gradeEnt.JournalColumn.GroupSubject.Subject.LectorRef != request.LectorId)
                    {
                        throw new Exception($"Actual LectorId({gradeEnt.JournalColumn.GroupSubject.Subject.LectorRef}) isn't compatible with given({request.LectorId}");
                    }

                    gradeEnt.Mark = request.Mark;

                    await _context.SaveChangesAsync(cancellationToken);

                    return gradeEnt.Id;
                }
                else
                {
                    throw new ArgumentException($"Grade with id({request.GradeId}) doesn't exists");
                }
            }
        }
    }
}
