using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, int>
    {
        private readonly ISSTDbContext _context;

        public CreateSubjectCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var existing = await _context.Subjects
                .FirstOrDefaultAsync(s => s.Name == request.Name && s.LectorRef == request.LectorId, cancellationToken);

            if (existing != null)
            {
                return existing.Id;
            }

            var entity = new Subject
            {
                Name = request.Name,
                LectorRef = request.LectorId
            };

            _context.Subjects.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
