using Enginex.Application.Email.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    public class ContactController : BaseController
    {
        public ViewResult Index()
        {
            return View(new SendEmailCommand());
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailCommand emailCommand)
        {
            await Mediator.Send(emailCommand);
            TempData["Message"] = $"Email has been sent.";
            return RedirectToAction("Index");
        }
    }
}
