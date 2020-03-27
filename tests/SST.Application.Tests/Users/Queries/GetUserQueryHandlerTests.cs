﻿using System;
using System.Collections.Generic;
using System.Text;
using SST.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using SST.Application.Tests.Common;
using SST.Application.Users.Queries.GetUser;

namespace SST.Application.Tests.Users.Queries
{
    [Collection("QueryCollection")]
    public class GetUserQueryHandlerTests
    {
        private readonly SSTDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;

        }

        [Fact]

        public async Task GetUserTest()
        {
            var sut = new GetUserQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetUserQuery { Email = "admin@email.com" }, CancellationToken.None);

            result.ShouldBeOfType<UserVm>();

            result.Email.ShouldBe("admin@email.com");
            result.IsAdmin.ShouldBeTrue();
        }
    }
}
