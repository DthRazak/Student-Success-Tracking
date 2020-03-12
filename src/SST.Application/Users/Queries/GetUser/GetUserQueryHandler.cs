﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Users
                .Where(x => x.Email == request.Email)
                .ProjectTo<UserVm>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            return vm;
        }
    }
}