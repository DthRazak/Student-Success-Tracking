using MediatR;
using SST.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Lectors.Commands.LinkLectorToUser
{
    public class LinkLectorToUserCommandHandler
    {
        private readonly ISSTDbContext _context;

        public LinkLectorToUserCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(LinkLectorToUserCommand request, CancellationToken cancellationToken)
        {
            var res = request.FullName.Split(" ");

            var entity = _context.Lectors
                .Where(x => x.FirstName == res[0]
                    && x.LastName == res[1])
                .FirstOrDefault();

            entity.UserRef = request.UserRef;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
