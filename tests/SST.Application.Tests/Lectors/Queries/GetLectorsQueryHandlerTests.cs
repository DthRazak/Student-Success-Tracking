using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using SST.Application.Common.Interfaces;
using SST.Application.Lectors.Queries.GetLectors;
using SST.Application.Tests.Common;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Lectors.Queries
{
    [Collection("QueryCollection")]
    public class GetLectorsQueryHandlerTests
    {
        private readonly SSTDbContext _context;
        private readonly IMapper _mapper;

        public GetLectorsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public async Task GetLectorsTest()
        {
            var sut = new GetLectorsQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetLectorsQuery { }, CancellationToken.None);

            result.ShouldBeOfType<LectorsListVm>();
        }
    }
}
