using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Commands.DeleteGradeByLector
{
    public class DeleteGradeByLectorCommandHandler : IRequestHandler<DeleteGradeByLectorCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public DeleteGradeByLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGradeByLectorCommand request, CancellationToken cancellationToken)
        {
            var gradeEnt = await _context.Grades
                .FindAsync(request.GradeId);

            if (gradeEnt != null)
            {
                if (gradeEnt.JournalColumn.GroupSubject.Subject.LectorRef != request.LectorId)
                {
                    throw new Exception($"Actual LectorId({gradeEnt.JournalColumn.GroupSubject.Subject.LectorRef}) isn't compatible with given({request.LectorId}");
                }

                _context.Grades.Remove(gradeEnt);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            else
            {
                throw new Exception($"Grade with id({request.GradeId}) doesn't exists");
            }
        }
    }
}
