using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, int>
    {
        private readonly ISSTDbContext _context;

        public CreateRequestCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = new Request
            {
                CreationDate = DateTime.Now,
                UserRef = request.UserRef
            };

            _context.Requests.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
