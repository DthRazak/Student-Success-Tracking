using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public UpdateUserCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(request.Email);

            if (entity == null)
            {
                throw new ArgumentException($"User with Email({request.Email}) does not exists!");
            }

            if (request.PasswordHash != null)
            {
                entity.PasswordHash = request.PasswordHash;
            }

            if (request.IsAdmin != null)
            {
                entity.IsAdmin = (bool)request.IsAdmin;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
