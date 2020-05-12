using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using SST.Application.Subjects.Queries;
using SST.Application.Subjects.Queries.GetSubjects;
using SST.Application.Tests.Common;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Subjects.Queries
{
    [Collection("QueryCollection")]
    public class GetSubjectsQueryHandlerTests
    {
        private readonly SSTDbContext _context;
        private readonly IMapper _mapper;

        public GetSubjectsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public async Task GetSubjectsTest()
        {
            var sut = new GetSubjectsQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetSubjectsQuery { }, CancellationToken.None);

            result.ShouldBeOfType<SubjectsListVm>();
        }
    }
}
