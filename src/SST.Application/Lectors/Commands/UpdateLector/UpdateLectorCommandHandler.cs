using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Commands.UpdateLector
{
    public class UpdateLectorCommandHandler : IRequestHandler<UpdateLectorCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public UpdateLectorCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLectorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Lectors
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new ArgumentException($"Lector with Id({request.Id}) does not exists!");
            }

            if (request.FirstName != null)
            {
                entity.FirstName = request.FirstName;
            }

            if (request.LastName != null)
            {
                entity.LastName = request.LastName;
            }

            if (request.AcademicStatus != null)
            {
                entity.AcademicStatus = request.AcademicStatus;
            }

            if (request.UserRef != null)
            {
                entity.UserRef = request.UserRef;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
