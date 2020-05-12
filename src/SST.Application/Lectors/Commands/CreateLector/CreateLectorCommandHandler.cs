using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Commands.CreateLector
{
    public class CreateLectorCommandHandler : IRequestHandler<CreateLectorCommand, int>
    {
        private readonly ISSTDbContext _context;

        public CreateLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLectorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Lector
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                AcademicStatus = request.AcademicStatus,
                UserRef = request.UserRef
            };

            _context.Lectors.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
