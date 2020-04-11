using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Enginex.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            return View("NotFound");
        }

        [Route("Error")]
        public IActionResult ErrorHandler()
        {
            // TODO log and send mail
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ErrorMessage = exceptionDetails?.Error?.Message;
            return View("Error");
        }
    }
}
