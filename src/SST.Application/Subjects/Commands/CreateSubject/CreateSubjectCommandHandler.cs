using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            var existing = _context.Subjects
                .FirstOrDefault(s => s.Name == request.Name && s.LectorRef == request.LectorId);

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
