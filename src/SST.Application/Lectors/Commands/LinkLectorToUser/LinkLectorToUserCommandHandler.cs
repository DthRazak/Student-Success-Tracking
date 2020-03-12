using MediatR;
using SST.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Lectors.Commands.LinkLectorToUser
{
    class LinkLectorToUserCommandHandler
    {
        private readonly ISSTDbContext _context;

        public LinkLectorToUserCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(LinkLectorToUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Lectors
                .Where(x => x.FirstName == x.FirstName
                    && x.LastName == x.LastName)
                .FirstOrDefault();

            entity.UserRef = request.UserRef;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
