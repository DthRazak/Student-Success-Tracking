using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using SST.Application.Lectors.Queries.GetNotLinkedLectors;
using SST.Application.Tests.Common;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Lectors.Queries
{
    [Collection("QueryCollection")]
    public class GetNotLinkedLectorsQueryHandlerTests
    {
        private readonly SSTDbContext _context;
        private readonly IMapper _mapper;

        public GetNotLinkedLectorsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public async Task GetNotLinkedLectorsTest()
        {
            var sut = new GetNotLinkedLectorsQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetNotLinkedLectorsQuery { }, CancellationToken.None);

            result.ShouldBeOfType<LectorListVm>();
        }
    }
}
