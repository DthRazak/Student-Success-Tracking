using MediatR;
using SST.Application.Common.Interfaces;
using SST.Application.Requests.Commands.CreateRequest;
using SST.Application.Students.Commands.LinkStudentToUser;
using SST.Application.Users.Commands.CreateUser;
using SST.Application.Users.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SST.WebUI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMediator _mediator;
        private readonly IPasswordHasher _passwordHasher;

        public AccountService(IMediator mediator, IPasswordHasher passwordHasher)
        {
            _mediator = mediator;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateStudentAccount(string email, string password, int studentId)
        {
            var model = await _mediator.Send(new GetUserQuery { Email = email });

            if (model == null)
            {
                _mediator.Send(new CreateUserCommand 
                    { Email = email, PasswordHash = _passwordHasher.GetPasswordHash(password) }).Wait();
                await _mediator.Send(new CreateRequestCommand { UserRef = email });
                await _mediator.Send(new LinkStudentToUserCommand { Id = studentId, UserRef = email });
            }
            else
            {
                throw new ArgumentException("Account already exists");
            }
        }
        
        public async Task CreateLectorAccount(string email, string password, int lectorId)
        {
            var model = await _mediator.Send(new GetUserQuery { Email = email });

            if (model != null)
            {
                _mediator.Send(new CreateUserCommand 
                    { Email = email, PasswordHash = _passwordHasher.GetPasswordHash(password) }).Wait();
                await _mediator.Send(new CreateRequestCommand { UserRef = email });
                await _mediator.Send(new LinkStudentToUserCommand { Id = lectorId, UserRef = email });
            }
            else
            {
                throw new ArgumentException("Account already exists");
            }
        }

        public async Task<ClaimsPrincipal> Login(string email, string password)
        {
            var model = await _mediator.Send(new GetUserQuery { Email = email });

            if (model != null && model.PasswordHash == _passwordHasher.GetPasswordHash(password))
            {
                if (model.IsApproved)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", 
                        ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                    return new ClaimsPrincipal(claimsIdentity);
                }
                else
                {
                    throw new Exception("Account is not approved");
                }
            }
            else
            {
                throw new ArgumentException("Wrong email or password");
            }
        }
    }
}
