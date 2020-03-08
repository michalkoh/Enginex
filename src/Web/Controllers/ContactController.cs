using Enginex.Domain;
using Enginex.Web.ViewModels;
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
            return View(new SendEmailCommandViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(SendEmailCommandViewModel sendEmailCommandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await this.captcha.IsValid(sendEmailCommandViewModel.CaptchaToken, HttpContext.Connection.RemoteIpAddress.ToString()))
                {
                    var command = sendEmailCommandViewModel.ToCommand();
                    await Mediator.Send(command);
                    ConfirmationMessage(this.localizer["EmailSent"]);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ErrorMessage(this.localizer["InvalidCaptcha"]);
                }
            }

            return View(nameof(Index), sendEmailCommandViewModel);
        }
    }
}
