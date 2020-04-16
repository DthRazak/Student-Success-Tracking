using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SST.Application.Students.Queries.GetStudent;
using SST.Application.Subjects.Queries.GetSubjectsByStudent;
using System.Linq;
using System.Threading.Tasks;

namespace SST.WebUI.Controllers
{
    [Authorize(Policy = "Student")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IMediator _mediator;

        public StudentController(ILogger<StudentController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Info()
        {
            var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            var model = await _mediator.Send(new GetStudentQuery { StudentId = id });

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Subjects()
        {
            var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            var model = await _mediator.Send(new GetSubjectsByStudentQuery { StudentId = id });

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Lectors()
        {
            var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            var model = await _mediator.Send(new GetSubjectsByStudentQuery { StudentId = id });

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Grades()
        {
            return View();
        }
    }
}
