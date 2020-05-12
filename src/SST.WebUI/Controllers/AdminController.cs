using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SST.Application.Common.Interfaces;
using SST.Application.Groups.Commands.CreateGroup;
using SST.Application.Groups.Commands.DeleteGroup;
using SST.Application.Groups.Queries.GetFaculties;
using SST.Application.Groups.Queries.GetGroups;
using SST.Application.Lectors.Commands.CreateLector;
using SST.Application.Lectors.Commands.DeleteLector;
using SST.Application.Lectors.Queries.GetLectors;
using SST.Application.Requests.Commands.UpdateRequest;
using SST.Application.Requests.Queries.GetNotApprovedRequests;
using SST.Application.Requests.Queries.GetRequests;
using SST.Application.Students.Commands.CreateStudent;
using SST.Application.Students.Commands.DeleteStudent;
using SST.Application.Students.Queries.GetStudents;
using SST.Application.Subjects.Commands.CreateSubject;
using SST.Application.Subjects.Commands.LinkSubjectToGroup;
using SST.Application.Subjects.Queries.GetSubjectsByLector;
using SST.Application.Users.Commands.CreateUser;
using SST.Application.Users.Commands.DeleteUser;
using SST.WebUI.Services.RazorToStringExample;
using SST.WebUI.ViewModels;

namespace SST.WebUI.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IMediator _mediator;
        private readonly RazorViewToStringRenderer _renderer;

        public AdminController(ILogger<AdminController> logger, IMediator mediator, RazorViewToStringRenderer renderer)
        {
            _logger = logger;
            _mediator = mediator;
            _renderer = renderer;
        }

        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Requests(bool? displayAll)
        {
            var model = new RequestModel();

            if (displayAll.HasValue && displayAll.Value)
            {
                model.AllRequestsList = await _mediator.Send(new GetRequestsQuery());
            }
            else
            {
                model.NotApprovedRequestsList = await _mediator.Send(new GetNotApprovedRequestsQuery());
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Students()
        {
            var studentsList = await _mediator.Send(new GetStudentsQuery());
            var groupList = await _mediator.Send(new GetGroupsQuery());

            var model = new AdminStudentsModel
            {
                StudentsList = studentsList,
                GroupsList = groupList
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Lectors()
        {
            var model = await _mediator.Send(new GetLectorsQuery());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Subjects()
        {
            var model = await _mediator.Send(new GetLectorsQuery());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Groups()
        {
            var groupsList = await _mediator.Send(new GetGroupsQuery());
            var facultyList = await _mediator.Send(new GetFacultiesQuery());

            var model = new AdminGroupsModel
            {
                GroupsList = groupsList,
                FacultyList = facultyList
            };

            return View(model);
        }

        [HttpGet]
        public async Task<List<string>> GetSubjectsByLector(int lectorId)
        {
            if (lectorId != -1)
            {
                var subjModel = await _mediator.Send(new GetSubjectsByLectorQuery { LectorId = lectorId });
                var linkModel = new AdminSubjectPatialModel
                {
                    GroupList = await _mediator.Send(new GetGroupsQuery()),
                    SubjectsList = subjModel
                };

                var list = new List<string>
                {
                    await _renderer.RenderViewToStringAsync("~/Views/Admin/LectorSubjectsPartial.cshtml", subjModel),
                    await _renderer.RenderViewToStringAsync("~/Views/Admin/LinkSubjectPartial.cshtml", linkModel)
                };

                return list;
            }
            else
            {
                var subjModel = new SubjectsListVm
                {
                    Subjects = new List<SubjectDto>()
                };
                var groupModel = new GroupsListVm
                {
                    Groups = new List<GroupsDto>()
                };
                var linkModel = new AdminSubjectPatialModel
                {
                    GroupList = groupModel,
                    SubjectsList = subjModel
                };

                var list = new List<string>
                {
                    await _renderer.RenderViewToStringAsync("~/Views/Admin/LectorSubjectsPartial.cshtml", subjModel),
                    await _renderer.RenderViewToStringAsync("~/Views/Admin/LinkSubjectPartial.cshtml", linkModel)
                };

                return list;
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApproveRequest(int id)
        {
            try
            {
                await _mediator.Send(new UpdateRequestCommand { Id = id, IsApproved = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> RejectRequest(int id)
        {
            try
            {
                await _mediator.Send(new UpdateRequestCommand { Id = id, IsApproved = false });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string email)
        {
            try
            {
                await _mediator.Send(new DeleteUserCommand { Email = email });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _mediator.Send(new DeleteStudentCommand { Id = id });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLector(int id)
        {
            try
            {
                await _mediator.Send(new DeleteLectorCommand { Id = id });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            try
            {
                await _mediator.Send(new DeleteGroupCommand { Id = id });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromForm]CreateStudentCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(command);
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            else
            {
                return UnprocessableEntity();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddLector([FromForm]CreateLectorCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(command);
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            else
            {
                return UnprocessableEntity();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup([FromForm]CreateGroupCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(command);
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            else
            {
                return UnprocessableEntity();
            }

            return NoContent();
        }

        public async Task<IActionResult> AddSubject([FromForm]CreateSubjectCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(command);
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            else
            {
                return UnprocessableEntity();
            }

            return NoContent();
        }

        public async Task<IActionResult> LinkSubject([FromForm]LinkSubjectToGroupCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(command);
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            else
            {
                return UnprocessableEntity();
            }

            return NoContent();
        }
    }
}
