using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Persistence;
using SST.WebUI.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace SST.WebUI.Tests.Services
{
    public class AccountServiceTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _output;

        public AccountServiceTest(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _output = output;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            Assert.True(true);
        }
    }
}
