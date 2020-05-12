using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using SST.Application.Common.Interfaces;
using SST.Application.Students.Queries.GetNotLinkedStudentsByGroup;
using SST.Application.Tests.Common;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Students.Queries
{
    [Collection("QueryCollection")]
    public class GetNotLinkedStudentsByGroupQueryHandlerTests
    {
        private readonly SSTDbContext _context;
        private readonly IMapper _mapper;

        public GetNotLinkedStudentsByGroupQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public async Task GetNotLinkedStudentsByGroupTest()
        {
            var sut = new GetNotLinkedStudentsByGroupQueryHandler(_context, _mapper);
            var result = await sut.Handle(new GetNotLinkedStudentsByGroupQuery { }, CancellationToken.None);

            result.ShouldBeOfType<StudentsListVm>();
        }
    }
}
