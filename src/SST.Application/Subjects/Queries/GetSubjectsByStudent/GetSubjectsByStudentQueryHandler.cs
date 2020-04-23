using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
                .Include(s => s.Group)
                .ThenInclude(g => g.GroupSubjects)
                .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

            var subjects = new List<SubjectDto>();
            foreach (var subject in student.Group.GroupSubjects)
            {
                subjects.Add(_mapper.Map<SubjectDto>(subject.Subject));
            }

            return new SubjectsListVm { Subjects = subjects };
        }
    }
}
