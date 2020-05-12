using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public DeleteGroupCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Groups
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new ArgumentException($"Group with Id({request.Id}) does not exists!");
            }

            _context.Groups.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
