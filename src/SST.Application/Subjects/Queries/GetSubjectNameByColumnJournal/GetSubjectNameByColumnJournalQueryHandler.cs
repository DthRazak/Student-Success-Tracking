using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Subjects.Queries.GetSubjectNameByColumnJournal
{
    public class GetSubjectNameByColumnJournalQueryHandler : IRequestHandler<GetSubjectNameByColumnJournalQuery, SubjectDto>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetSubjectNameByColumnJournalQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubjectDto> Handle(GetSubjectNameByColumnJournalQuery request, CancellationToken cancellationToken)
        {
            var journalColumn = await _context.JournalColumns
                .Include(jc => jc.GroupSubject)
                    .ThenInclude(gs => gs.Subject)
                .FirstOrDefaultAsync(x => x.Id == request.JournalColumnId, cancellationToken);

            return new SubjectDto { Name = journalColumn.GroupSubject.Subject.Name };
        }
    }
}
