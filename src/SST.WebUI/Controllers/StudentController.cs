using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SST.Application.Journal.Queries.GetJournalByStudentAndSubject;
using SST.Application.Students.Queries.GetStudent;
using SST.Application.Subjects.Queries.GetSubjectsByStudent;

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

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Grades()
        {
            var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            var model = await _mediator.Send(new GetSubjectsByStudentQuery { StudentId = id });

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DisplayGrages(int subjectId)
        {
            var studentId = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            var model = await _mediator.Send(new GetJournalByStudentAndSubjectQuery
                { StudentId = studentId, SubjectId = subjectId });

            return PartialView("GradesPartial", model);
        }
    }
}
