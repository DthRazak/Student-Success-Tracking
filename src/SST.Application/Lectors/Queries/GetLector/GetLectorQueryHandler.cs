using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;

namespace SST.Application.Lectors.Queries.GetLector
{
    public class GetLectorQueryHandler : IRequestHandler<GetLectorQuery, LectorVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetLectorQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LectorVm> Handle(GetLectorQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Lectors
                .SingleOrDefaultAsync(s => s.Id == request.LectorId, cancellationToken);

            return _mapper.Map<LectorVm>(student);
        }
    }
}
