using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Requests.Queries.GetRequests
{
    public class GetRequestsQueryHandler : IRequestHandler<GetRequestsQuery, RequestsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetRequestsQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RequestsListVm> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
        {
            var requests = await _context.Requests
                .Where(r => r.User.IsAdmin == false)
                .OrderBy(r => r.CreationDate)
                .ProjectTo<RequestDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new RequestsListVm
            {
                Requests = requests
            };

            return vm;
        }
    }
}
