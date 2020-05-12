using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Subjects.Queries.GetSubjectsByStudent
{
    public class GetSubjectsByStudentQueryHandler : IRequestHandler<GetSubjectsByStudentQuery, SubjectsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetSubjectsByStudentQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubjectsListVm> Handle(GetSubjectsByStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

            var subjects = await _context.GroupSubjects
               .Include(gs => gs.Subject)
                   .ThenInclude(s => s.Lector)
               .Where(gs => gs.GroupRef == student.GroupRef)
               .ProjectTo<SubjectDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new SubjectsListVm { Subjects = subjects };
        }
    }
}
