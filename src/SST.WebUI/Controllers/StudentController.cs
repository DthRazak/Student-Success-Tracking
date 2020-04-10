using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Subjects()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lectors()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Grades()
        {
            return View();
        }
    }
}
