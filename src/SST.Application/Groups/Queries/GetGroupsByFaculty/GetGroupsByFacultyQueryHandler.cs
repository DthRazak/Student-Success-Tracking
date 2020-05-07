using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Groups.Queries.GetGroupsByFaculty
{
    public class GetGroupsByFacultyQueryHandler : IRequestHandler<GetGroupsByFacultyQuery, GroupsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetGroupsByFacultyQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GroupsListVm> Handle(GetGroupsByFacultyQuery request, CancellationToken cancellationToken)
        {
            var groups = await _context.Groups
               .Where(g => g.Faculty == request.Faculty)
               .OrderBy(g => g.Name)
               .ProjectTo<GroupsDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new GroupsListVm { Groups = groups };
        }
    }
}
