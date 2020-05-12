using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using SST.Application.Common.Interfaces;
using SST.Application.Groups.Queries.GetFaculties;
using SST.Application.Subjects.Queries.GetSubjectsByLector;
using SST.Application.Tests.Common;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Subjects.Queries
{
    [Collection("QueryCollection")]
    public class GetSubjectsByLectorQueryHandlerTests
    {
        private readonly SSTDbContext _context;
        private readonly IMapper _mapper;

        public GetSubjectsByLectorQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public async Task GetSubjectsByLectorTest()
        {
            var sut = new GetSubjectsByLectorQueryHandler(_context, _mapper);
            var result = await sut.Handle(new GetSubjectsByLectorQuery { }, CancellationToken.None);

            result.ShouldBeOfType<SubjectsListVm>();
        }
    }
}
