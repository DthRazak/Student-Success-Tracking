using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SST.Application.Tests.Common;
using SST.Application.Users.Commands.CreateUser;
using Xunit;

namespace SST.Application.Tests.Users.Commands
{
    public class CreateUserCommandHandlerTests : CommandTestBase
    {
        private readonly CreateUserCommandHandler _sut;

        public CreateUserCommandHandlerTests()
            : base()
        {
            _sut = new CreateUserCommandHandler(_context);
        }

        [Fact]

        public void Handle_GivenInvalidEmail_ThrowsNotFoundException()
        {
            var invalidPass = "INVLD";

            var command = new CreateUserCommand { Email = invalidPass };
        }
    }
}
