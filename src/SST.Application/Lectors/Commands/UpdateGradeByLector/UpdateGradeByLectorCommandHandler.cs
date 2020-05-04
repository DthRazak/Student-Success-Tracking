using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Lectors.Commands.UpdateGradeByLector
{
    public class UpdateGradeByLectorCommandHandler : IRequestHandler<UpdateGradeByLectorCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public UpdateGradeByLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGradeByLectorCommand request, CancellationToken cancellationToken)
        {
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

                if (request.StudentId != null)
                    gradeEnt.StudentRef = (int)request.StudentId;
                if (request.JournalColumnId != null)
                    gradeEnt.JournalColumnRef = (int)request.JournalColumnId;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            else
            {
                throw new ArgumentException($"Grade with id({request.GradeId}) doesn't exists");
            }
        }
    }
}
