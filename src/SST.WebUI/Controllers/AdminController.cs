using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SST.Application.Common.Interfaces;
using SST.Application.Lectors.Commands.CreateLector;
using SST.Application.Lectors.Commands.DeleteLector;
using SST.Application.Lectors.Queries.GetLectors;
using SST.Application.Requests.Commands.UpdateRequest;
using SST.Application.Requests.Queries.GetNotApprovedRequests;
using SST.Application.Requests.Queries.GetRequests;
using SST.Application.Students.Commands.CreateStudent;
using SST.Application.Students.Commands.DeleteStudent;
using SST.Application.Students.Queries.GetStudents;
using SST.Application.Users.Commands.CreateUser;
using SST.Application.Users.Commands.DeleteUser;
using SST.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SST.WebUI.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IMediator _mediator;

        public AdminController(ILogger<AdminController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Info()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Requests(bool? DisplayAll)
        {
            var model = new RequestModel();

            if (DisplayAll.HasValue && DisplayAll.Value)
                model.AllRequestsList = await _mediator.Send(new GetRequestsQuery());
            else
                model.NotApprovedRequestsList = await _mediator.Send(new GetNotApprovedRequestsQuery());
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Students()
        {
            var model = await _mediator.Send(new GetStudentsQuery());

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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Groups()
        {
            return View();
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
    }
}
