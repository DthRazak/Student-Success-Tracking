using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Students.Queries.GetStudent
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentVm> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .Include(s => s.Group)
                .SingleOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

            return _mapper.Map<StudentVm>(student);
        }
    }
}
