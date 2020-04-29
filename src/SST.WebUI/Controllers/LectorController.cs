using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SST.Application.Subjects.Queries.GetSubjectsByLector;
using Microsoft.AspNetCore.Mvc;

namespace SST.WebUI.Controllers
{
	[Authorize(Policy = "Lector")]
	public class LectorController : Controller
	{
		private readonly ILogger<LectorController> _logger;
		private readonly IMediator _mediator;

		public LectorController(ILogger<LectorController> logger, IMediator mediator)
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
			var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

			var model = await _mediator.Send(new GetSubjectsByLectorQuery { LectorId = id });

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Gradebook()
		{
			return View();
		}
	}
}
