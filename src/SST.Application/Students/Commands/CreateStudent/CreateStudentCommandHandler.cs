using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Students.Commands.CreateStudent
{
    class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly ISSTDbContext _context;

        public CreateStudentCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Student
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Group = request.Group,
                UserRef = request.UserRef
            };

            _context.Students.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
