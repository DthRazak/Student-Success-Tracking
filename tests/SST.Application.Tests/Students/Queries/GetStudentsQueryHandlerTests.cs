using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using SST.Application.Students.Queries.GetStudents;
using SST.Application.Tests.Common;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Students.Queries
{
    [Collection("QueryCollection")]
    public class GetStudentsQueryHandlerTests
    {
        private readonly SSTDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public async Task GetStudentsTest()
        {
            var sut = new GetStudentsQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetStudentsQuery { }, CancellationToken.None);

            result.ShouldBeOfType<StudentsListVm>();
        }
    }
}
