using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Lectors.Commands.LinkLectorToUser
{
    public class LinkLectorToUserCommandHandler : IRequestHandler<LinkLectorToUserCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public LinkLectorToUserCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(LinkLectorToUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Lectors
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            entity.UserRef = request.UserRef;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
