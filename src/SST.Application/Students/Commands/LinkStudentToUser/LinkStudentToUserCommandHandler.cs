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
            var res = request.FullName.Split(" ");

            var entity = _context.Students
                .Where(x => x.Group == request.Group
                    && x.FirstName == res[0]
                    && x.LastName == res[1])
                .FirstOrDefault();

            entity.UserRef = request.UserRef;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
