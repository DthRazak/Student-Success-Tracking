using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Lectors.Queries.GetLectors
{
    public class GetLectorsQueryHandler : IRequestHandler<GetLectorsQuery, LectorsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetLectorsQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LectorsListVm> Handle(GetLectorsQuery request, CancellationToken cancellationToken)
        {
            var lectors = await _context.Lectors
                .ProjectTo<LectorDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new LectorsListVm
            {
                Lectors = lectors
            };

            return vm;
        }
    }
}
