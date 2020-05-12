using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public UpdateStudentCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new ArgumentException($"Student with Id({request.Id}) does not exists!");
            }

            if (request.FirstName != null)
            {
                entity.FirstName = request.FirstName;
            }

            if (request.LastName != null)
            {
                entity.LastName = request.LastName;
            }

            if (request.GroupRef != null)
            {
                entity.GroupRef = request.GroupRef.Value;
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
