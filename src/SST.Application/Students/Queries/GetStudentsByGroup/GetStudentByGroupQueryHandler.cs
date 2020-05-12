using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Students.Queries.GetStudentsByGroup
{
    public class GetStudentByGroupQueryHandler : IRequestHandler<GetStudentByGroupQuery, StudentsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentByGroupQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentsListVm> Handle(GetStudentByGroupQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Students
                .Where(x => x.GroupRef == request.GroupId)
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new StudentsListVm
            {
                Students = students
            };

            return vm;
        }
    }
}
