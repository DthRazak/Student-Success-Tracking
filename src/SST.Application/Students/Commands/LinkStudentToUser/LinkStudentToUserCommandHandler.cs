using MediatR;
using SST.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Students.Commands.LinkStudentToUser
{
    public class LinkStudentToUserCommandHandler : IRequestHandler<LinkStudentToUserCommand>
    {
        private readonly ISSTDbContext _context;

        public LinkStudentToUserCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(LinkStudentToUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Students
                .Where(x => x.Group == request.Group
                    && x.FirstName == x.FirstName
                    && x.LastName == x.LastName)
                .FirstOrDefault();

            entity.UserRef = request.UserRef;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
