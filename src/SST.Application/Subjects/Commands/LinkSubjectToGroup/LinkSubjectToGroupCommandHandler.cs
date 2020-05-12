using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;

namespace SST.Application.Subjects.Commands.LinkSubjectToGroup
{
    public class LinkSubjectToGroupCommandHandler : IRequestHandler<LinkSubjectToGroupCommand>
    {
        private readonly ISSTDbContext _context;

        public LinkSubjectToGroupCommandHandler(ISSTDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(LinkSubjectToGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GroupSubjects
                .FirstOrDefaultAsync(x => x.SubjectRef == request.SubjectId && x.GroupRef == request.GroupId, cancellationToken);

            if (entity == null)
            {
                var newEntity = new GroupSubject
                {
                    GroupRef = request.GroupId,
                    SubjectRef = request.SubjectId
                };

                _context.GroupSubjects.Add(newEntity);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
