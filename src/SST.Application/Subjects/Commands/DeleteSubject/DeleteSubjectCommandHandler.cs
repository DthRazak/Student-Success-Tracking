using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public DeleteSubjectCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects
                .FindAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new ArgumentException($"Subject with Id({request.Id}) does not exists!");
            }

            _context.Subjects.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
