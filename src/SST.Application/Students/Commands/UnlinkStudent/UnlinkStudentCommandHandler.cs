using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Students.Commands.UnlinkStudent
{
    public class UnlinkStudentCommandHandler : IRequestHandler<UnlinkStudentCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public UnlinkStudentCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UnlinkStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            entity.UserRef = null;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
