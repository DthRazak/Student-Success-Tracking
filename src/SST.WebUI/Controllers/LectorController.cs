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
using SST.Application.Lectors.Commands.UpdateJournalColumnByLector;
using SST.Application.Lectors.Commands.UpdateGradeByLector;
using SST.Application.Lectors.Commands.CreateGradeByLector;
using SST.Application.Students.Queries.GetStudent;
using SST.WebUI.Hubs;
using SST.Application.Subjects.Queries.GetSubjectNameByColumnJournal;

namespace SST.WebUI.Controllers
{
    [Authorize(Policy = "Lector")]
    public class LectorController : Controller
    {
        private readonly ILogger<LectorController> _logger;
        private readonly IMediator _mediator;
        private readonly NotificationHub _notificationHub;

        public LectorController(ILogger<LectorController> logger, IMediator mediator, NotificationHub notificationHub)
        {
            _logger = logger;
            _mediator = mediator;
            _notificationHub = notificationHub;
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

        [HttpPost]
        public async Task<IActionResult> UpdateJournalColumn(int colId, string note, string date)
        {
            var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            try
            {
                DateTime? dateTime = date != null ? (DateTime?)DateTime.Parse(date) : null;

                await _mediator.Send(new UpdateJournalColumnByLectorCommand
                { JournalColumnId = colId,  Date = dateTime, Note = note, LectorId = id });

                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                return UnprocessableEntity();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGroupColumn(int gradeId, int mark, int colId, int stId)
        {
            var id = int.Parse(User.Claims.First(x => x.Type == "SST-ID").Value);

            try
            {
                await _mediator.Send(new UpdateGradeByLectorCommand
                { GradeId = gradeId, Mark = mark, LectorId = id });

                await NotifyStudentAboutNewMark(stId, mark, colId);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                try
                {
                    await _mediator.Send(new CreateGradeByLectorCommand
                    { Mark = mark, LectorId = id, JournalColumnId = colId, StudentId = stId });

                    await NotifyStudentAboutNewMark(stId, mark, colId);

                    return Ok();
                }
                catch (Exception inEx)
                {
                    _logger.LogError(inEx.Message);

                    return UnprocessableEntity();
                }
            }
        }

        private async Task NotifyStudentAboutNewMark(int studentId, int mark, int colId)
        {
            var student = await _mediator.Send(new GetStudentQuery { StudentId = studentId });
            var subject = await _mediator.Send(new GetSubjectNameByColumnJournalQuery { JournalColumnId = colId });

            if (student.Email != null)
            {
                await _notificationHub.NotifySudent(student.Email, subject.Name, mark);
            }
        }
    }
}
