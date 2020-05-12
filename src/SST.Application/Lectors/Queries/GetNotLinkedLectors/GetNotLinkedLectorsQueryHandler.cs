using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Lectors.Queries.GetNotLinkedLectors
{
    public class GetNotLinkedLectorsQueryHandler : IRequestHandler<GetNotLinkedLectorsQuery, LectorListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetNotLinkedLectorsQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LectorListVm> Handle(GetNotLinkedLectorsQuery request, CancellationToken cancellationToken)
        {
            var lectors = await _context.Lectors
                .Where(x => x.User == null)
                .ProjectTo<LectorDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new LectorListVm
            {
                Lectors = lectors
            };

            return vm;
        }
    }
}
