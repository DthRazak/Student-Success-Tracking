using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Lectors.Commands.UnlinkLector
{
    public class UnlinkLectorCommandHandler : IRequestHandler<UnlinkLectorCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public UnlinkLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UnlinkLectorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Lectors
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            entity.UserRef = null;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
