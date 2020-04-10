using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SST.Application.Students.Commands.CreateStudent;
using SST.WebUI.Tests.Common;
using Xunit;


namespace SST.WebUI.tests.Controllers
{
    public class AdminControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public AdminControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]

        public async Task GivenCreateStudentCommand_ReturnsSuccessStatusCode()
        {
            var client = _factory.GetAdminUser();

            var command = new CreateStudentCommand
            {
                FirstName = "Ілон",
                LastName = "Маск",
                Group = "ПМІ-32"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync("/Admin/AddStudent", content);

            response.EnsureSuccessStatusCode();
        }

    }
}
