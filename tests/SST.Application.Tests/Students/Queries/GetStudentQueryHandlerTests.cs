using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using SST.Application.Students.Queries.GetStudent;
using SST.Application.Tests.Common;
using SST.Persistence;
using Xunit;

namespace SST.Application.Tests.Students.Queries
{
    [Collection("QueryCollection")]
    public class GetStudentQueryHandlerTests
    {
        private readonly SSTDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public async Task GetStudentTest()
        {
            var sut = new GetStudentQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetStudentQuery { StudentId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<StudentVm>();
        }
    }
}
