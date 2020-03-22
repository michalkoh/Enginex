using Enginex.Domain;
using Enginex.Web.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IStringLocalizer<ContactController> localizer;
        private readonly ICaptcha captcha;

        public ContactController(IStringLocalizer<ContactController> localizer, ICaptcha captcha)
        {
            this.localizer = localizer;
            this.captcha = captcha;
        }

        public ViewResult Index()
        {
            return View(new ContactViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await this.captcha.IsValid(contactViewModel.CaptchaToken, HttpContext.Connection.RemoteIpAddress.ToString()))
                {
                    var command = contactViewModel.ToCommand();
                    await Mediator.Send(command);
                    ConfirmationMessage(this.localizer["EmailSent"]);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ErrorMessage(this.localizer["InvalidCaptcha"]);
                }
            }

            return View(nameof(Index), contactViewModel);
        }
    }
}
