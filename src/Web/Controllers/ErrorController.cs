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
    }
}
