using System;
using System.Net.Http;
using System.Threading.Tasks;
using SST.WebUI.Tests.Common;
using Xunit;

namespace SST.WebUI.tests.Controllers
{
    public class AccountControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public AccountControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetLectorsTest()
        {
            HttpClient client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/Account/GetLectors");

            response.EnsureSuccessStatusCode();
        }
    }
}
