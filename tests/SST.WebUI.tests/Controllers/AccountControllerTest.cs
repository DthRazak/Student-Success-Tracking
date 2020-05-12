using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SST.WebUI.Tests.Common;
using Xunit;

namespace SST.WebUI.Tests.Controllers
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

        [Fact]
        public async Task GetStudentsByGroupTest()
        {
            HttpClient client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/Account/GetStudentsByGroup?group=" + WebUtility.UrlEncode("ПМІ-32"));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task SignupAsLectorTest()
        {
            HttpClient client = _factory.GetAnonymousClient();

            var content = new FormUrlEncodedContent(new[]
{
                new KeyValuePair<string, string>("Email", "amuzychuk@gmail.com"),
                new KeyValuePair<string, string>("Password", "Password"),
                new KeyValuePair<string, string>("ConfirmPassword", "Password"),
                new KeyValuePair<string, string>("LectorId", "1"),
});

            var response = await client.PostAsync("/Account/SignupAsLector", content);
            response.EnsureSuccessStatusCode();
        }

        // Students/Info not found
        [Fact]
        public async Task LoginTest()
        {
            HttpClient client = _factory.GetAnonymousClient();

            var content = new FormUrlEncodedContent(new[]
{
                new KeyValuePair<string, string>("Email", "admin@email.com"),
                new KeyValuePair<string, string>("Password", "admin"),
});

            var response = await client.PostAsync("/Account/Login", content);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task SignupAsStudentTest()
        {
            HttpClient client = _factory.GetAnonymousClient();

            var content = new FormUrlEncodedContent(new[]
{
                new KeyValuePair<string, string>("Email", "martashuyak@gmail.com"),
                new KeyValuePair<string, string>("Password", "Password"),
                new KeyValuePair<string, string>("ConfirmPassword", "Password"),
                new KeyValuePair<string, string>("StudentId", "2"),
});

            var response = await client.PostAsync("/Account/SignupAsStudent", content);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task SignupTest()
        {
            HttpClient client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/Account/Signup");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetLoginTest()
        {
            HttpClient client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/Account/Login");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task LogoutTest()
        {
            HttpClient client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/Account/Logout");

            response.EnsureSuccessStatusCode();
        }
    }
}
