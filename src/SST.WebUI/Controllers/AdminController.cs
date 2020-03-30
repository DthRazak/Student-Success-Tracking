using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SST.Application.Common.Interfaces;
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
        private readonly IAccountService _accountService;

        public AdminController(ILogger<AdminController> logger, IMediator mediator, IAccountService accountService)
        {
            _logger = logger;
            _mediator = mediator;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Info()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Requests()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Students()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lectors()
        {
            return View();
        }
    }
}
