using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SST.Application.Subjects.Queries.GetSubjectsByLector;
using SST.Application.Lectors.Queries.GetLector;
using Microsoft.AspNetCore.Mvc;
using SST.Application.Journal.Queries.GetJournalByGroupAndSubject;
using SST.Application.Lectors.Commands.DeleteJournalColumnByLector;
using SST.Application.Lectors.Commands.CreateJournalColumnByLector;

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
            var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            var model = await _mediator.Send(new GetLectorQuery { LectorId = id });

            return View(model);
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
            var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            var model = await _mediator.Send(new GetSubjectsByLectorQuery { LectorId = id });

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DisplayGrages(int subjectId, int groupId)
        {
            var model = await _mediator.Send(new GetJournalByGroupAndSubjectQuery
            { GroupId = groupId, SubjectId = subjectId });

            return PartialView("GradesPartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddJournalColumn(int journalId, string date)
        {
            var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            try
            {
                var journalColumnId = await _mediator.Send(new CreateJournalColumnByLectorCommand
                { Date = DateTime.Parse(date), GroupSubjectId = journalId, LectorId = id });

                return Ok(journalColumnId);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                return UnprocessableEntity();
            }
        }
    }
}
