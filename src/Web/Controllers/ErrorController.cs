using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Enginex.Web.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger logger;

        public ErrorController(ILogger logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            return View("NotFound");
        }

        [Route("Error")]
        public IActionResult ErrorHandler()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            this.logger.Fatal($"Path: {exceptionDetails?.Path} Exception: {exceptionDetails?.Error}");
            ViewBag.ErrorMessage = exceptionDetails?.Error?.Message;
            return View("Error");
        }
    }
}
