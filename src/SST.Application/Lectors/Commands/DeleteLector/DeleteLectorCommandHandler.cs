using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Commands.DeleteLector
{
    public class DeleteLectorCommandHandler : IRequestHandler<DeleteLectorCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public DeleteLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLectorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Lectors
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new ArgumentException($"Lector with Id({request.Id}) does not exists!");
            }

            _context.Lectors.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
