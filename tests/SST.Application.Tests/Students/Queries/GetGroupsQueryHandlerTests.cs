using System;
using System.Collections.Generic;
using System.Text;
using SST.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using SST.Application.Tests.Common;
using SST.Application.Groups.Queries.GetGroups;

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
            var sut = new GetGroupsQueryHandler(_context);

            var result = await sut.Handle(new GetGroupsQuery {  }, CancellationToken.None);

            result.ShouldBeOfType<GroupsListVm>();



        }

    }
}
