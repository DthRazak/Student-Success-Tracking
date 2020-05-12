using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

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
            var entity = await _context.Students
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            entity.UserRef = request.UserRef;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
