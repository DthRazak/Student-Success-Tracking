using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Students.Queries.GetStudents
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, StudentsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentsListVm> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Students
                .Include(s => s.Group)
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
