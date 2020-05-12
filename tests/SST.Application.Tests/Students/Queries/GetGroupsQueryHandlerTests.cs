using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using SST.Application.Groups.Queries.GetGroups;
using SST.Application.Tests.Common;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Students.Queries
{
    [Collection("QueryCollection")]
    public class GetGroupsQueryHandlerTests
    {
        private readonly SSTDbContext _context;

        public GetGroupsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]

        public async Task GetGroupsTest()
        {
            // var sut = new GetGroupsQueryHandler(_context);

            // var result = await sut.Handle(new GetGroupsQuery {  }, CancellationToken.None);

            // result.ShouldBeOfType<GroupsListVm>();
        }
    }
}
