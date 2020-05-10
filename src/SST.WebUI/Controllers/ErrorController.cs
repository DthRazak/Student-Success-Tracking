using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SST.WebUI.ViewModels;

namespace SST.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult HandlePageNotFound()
        {
            return View("NotFound");
        }

        [Route("Error/403")]
        public IActionResult HandleAccessDenied()
        {
            return View("AccessDenied");
        }
    }
}
