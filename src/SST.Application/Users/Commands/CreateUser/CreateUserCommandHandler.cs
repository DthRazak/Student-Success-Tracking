using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly ISSTDbContext _context;

        public CreateUserCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User
            {
                Email = request.Email,
                PasswordHash = ComputeHash(request.Password),
                IsAdmin = false
            };

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Email;
        }

        private static string ComputeHash(string rawData)
        {
            //TODO this method

            return rawData;
        }
    }
}
