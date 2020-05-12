using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly ISSTDbContext _context;

        public DeleteStudentCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new ArgumentException($"Student with Id({request.Id}) does not exists!");
            }

            _context.Students.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
