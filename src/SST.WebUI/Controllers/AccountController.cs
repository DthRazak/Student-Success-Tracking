using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SST.Application.Common.Interfaces;
using SST.Application.Groups.Queries.GetFaculties;
using SST.Application.Groups.Queries.GetGroups;
using SST.Application.Groups.Queries.GetGroupsByFaculty;
using SST.Application.Lectors.Queries.GetNotLinkedLectors;
using SST.Application.Students.Queries.GetNotLinkedStudentsByGroup;
using SST.WebUI.Forms;
using SST.WebUI.ViewModels;

namespace SST.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IMediator mediator, IAccountService accountService)
        {
            _logger = logger;
            _mediator = mediator;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Signup()
        {
            var facultyList = await _mediator.Send(new GetFacultiesQuery());
            var model = new SignupModel
            {
                FacultyList = facultyList,
                StudentSignupForm = new StudentSignupForm(),
                LectorSignupForm = new LectorSignupForm()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            if (User.HasClaim(x => x.Type == ClaimTypes.Role))
            {
                return RedirectToAction("Info", User.Claims.Single(c => c.Type == ClaimTypes.Role).Value);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]

        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                ClaimsPrincipal claimsPrinciple;
                try
                {
                    claimsPrinciple = await _accountService.Login(
                        form.Email, form.Password);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(form);
                }

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrinciple);

                return RedirectToAction("Info", claimsPrinciple.Claims.Single(c => c.Type == ClaimTypes.Role).Value);
            }

            return View(form);
        }

        [HttpPost]

        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignupAsLector(LectorSignupForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountService.CreateLectorAccount(form.Email, form.Password, form.LectorId);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                return RedirectToAction("Login", "Account");
            }

            var facultyList = await _mediator.Send(new GetFacultiesQuery());
            var model = new SignupModel
            {
                FacultyList = facultyList,
                StudentSignupForm = new StudentSignupForm(),
                LectorSignupForm = new LectorSignupForm()
            };

            return View("Signup", model);
        }

        [HttpPost]

        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignupAsStudent(StudentSignupForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountService.CreateStudentAccount(form.Email, form.Password, form.StudentId);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                return RedirectToAction("Login", "Account");
            }

            var facultyList = await _mediator.Send(new GetFacultiesQuery());
            var model = new SignupModel
            {
                FacultyList = facultyList,
                StudentSignupForm = new StudentSignupForm(),
                LectorSignupForm = new LectorSignupForm()
            };

            return View("Signup", model);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsByGroup(int group)
        {
            try
            {
                var model = await _mediator.Send(new GetNotLinkedStudentsByGroupQuery { Group = group });

                return PartialView("StudentsPartial", model);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                var model = new StudentsListVm
                {
                    Students = new List<StudentDto>()
                };

                return PartialView("StudentsPartial", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupsByFaculty(string faculty)
        {
            try
            {
                var model = await _mediator.Send(new GetGroupsByFacultyQuery { Faculty = faculty });

                return PartialView("GroupsPartial", model);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                var model = new Application.Groups.Queries.GetGroupsByFaculty.GroupsListVm()
                {
                    Groups = new List<Application.Groups.Queries.GetGroupsByFaculty.GroupsDto>()
                };

                return PartialView("GroupsPartial", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLectors()
        {
            try
            {
                var model = await _mediator.Send(new GetNotLinkedLectorsQuery());

                return PartialView("LectorsPartial", model);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                var model = new LectorListVm
                {
                    Lectors = new List<LectorDto>()
                };

                return PartialView("LectorsPartial", model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> ChangePassword(ChangePasswordForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountService.ChangePassword(User.Identity.Name, form.OldPassword, form.Password);
                }
                catch (ArgumentException ex)
                {
                    return UnprocessableEntity(ex.Message);
                }
            }
            else
            {
                var messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                return UnprocessableEntity(messages);
            }

            return NoContent();
        }
    }
}
