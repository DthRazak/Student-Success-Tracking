using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using SST.Application.Subjects.Queries;
using SST.Application.Subjects.Queries.GetSubjectsByStudent;
using SST.Application.Tests.Common;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Subjects.Queries
{
    [Collection("QueryCollection")]
    public class GetSubjectsByStudentQueryHandlerTests
    {
        private readonly SSTDbContext _context;
        private readonly IMapper _mapper;

        public GetSubjectsByStudentQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public async Task GetSubjectsByStudentTest()
        {
            var sut = new GetSubjectsByStudentQueryHandler(_context, _mapper);
            var result = await sut.Handle(new GetSubjectsByStudentQuery { StudentId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<SubjectsListVm>();
        }
    }
}
