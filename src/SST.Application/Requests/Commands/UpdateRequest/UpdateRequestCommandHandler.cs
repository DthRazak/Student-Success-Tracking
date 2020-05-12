using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Requests.Commands.UpdateRequest
{
    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public UpdateRequestCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Requests
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new ArgumentException($"Request with Id({request.Id}) does not exists!");
            }

            if (request.IsApproved != null)
            {
                entity.IsApproved = (bool)request.IsApproved;
            }

            if (request.CreationDate != null)
            {
                entity.CreationDate = (DateTime)request.CreationDate;
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
