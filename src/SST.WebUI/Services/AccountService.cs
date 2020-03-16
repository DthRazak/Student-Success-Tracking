using MediatR;
using SST.Application.Common.Interfaces;
using SST.Application.Requests.Commands.CreateRequest;
using SST.Application.Students.Commands.LinkStudentToUser;
using SST.Application.Users.Commands.CreateUser;
using SST.Application.Users.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SST.WebUI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMediator _mediator;

        public AccountService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task CreateStudentAccount(string email, string password, int studentId)
        {
            var model = await _mediator.Send(new GetUserQuery { Email = email });

            if (model == null)
            {
                _mediator.Send(new CreateUserCommand { Email = email, PasswordHash = CalculateHash(password) }).Wait();
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
                _mediator.Send(new CreateUserCommand { Email = email, PasswordHash = CalculateHash(password) }).Wait();
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

            if (model != null && model.PasswordHash == CalculateHash(password))
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

        private static string CalculateHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            var hash = pbkdf2.GetBytes(32);

            var hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
