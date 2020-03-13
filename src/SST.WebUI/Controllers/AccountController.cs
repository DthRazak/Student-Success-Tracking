using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SST.Application.Requests.Commands.CreateRequest;
using SST.Application.Students.Commands.LinkStudentToUser;
using SST.Application.Users.Commands.CreateUser;
using SST.Application.Users.Queries.GetUser;
using SST.Application.Students.Queries.GetGroups;
using SST.WebUI.Forms;
using SST.WebUI.ViewModels;
using System.Text.Json;
using SST.Application.Students.Queries.GetStudentsByGroup;

namespace SST.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        public AccountController(ILogger<AccountController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Signup()
        {
            var model = new SignupModel
            {
                GroupsList = await _mediator.Send(new GetGroupsQuery()),
                SignupForm = new SignupForm()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginForm form)
        {
            var model = await _mediator.Send(new GetUserQuery { Email = form.Email });
            var hash = form.Password; //TODO: hash

            if (model.PasswordHash.TrimEnd() == hash)
            {
                await Authenticate(model.Email);

                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("", "Invalid login or password");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(SignupForm form)
        {
            await _mediator.Send(new CreateUserCommand { Email = form.Email, PasswordHash = form.Password });
            await _mediator.Send(new CreateRequestCommand { UserRef = form.Email });
            await _mediator.Send(new LinkStudentToUserCommand
                { Group = form.Group, FullName = form.FullName, UserRef = form.Email });

            return RedirectToAction("Account", "Login");
        }

        [HttpGet]
        public async Task<string> GetStudentsByGroup(string group)
        {
            return JsonSerializer.Serialize(await _mediator.Send(new GetStudentByGroupQuery { Group = group}));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
