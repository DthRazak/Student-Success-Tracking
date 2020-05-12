using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Requests.Queries.GetNotApprovedRequests
{
    public class GetNotApprovedRequestsHandler : IRequestHandler<GetNotApprovedRequestsQuery, RequestsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetNotApprovedRequestsHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RequestsListVm> Handle(GetNotApprovedRequestsQuery request, CancellationToken cancellationToken)
        {
            var requests = await _context.Requests
                .Where(r => r.IsApproved == null)
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
