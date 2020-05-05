using Enginex.Domain;
using Enginex.Web.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Serilog;

namespace Enginex.Web.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IStringLocalizer<ContactController> localizer;
        private readonly ICaptcha captcha;
        private readonly ILogger logger;

        public ContactController(IStringLocalizer<ContactController> localizer, ICaptcha captcha, ILogger logger)
        {
            this.localizer = localizer;
            this.captcha = captcha;
            this.logger = logger;
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
                    this.logger.Information($"Contact request from '{contactViewModel.Email}' has been sent.");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    this.logger.Error("Failed to send an email message due to invalid CAPTCHA.");
                    ErrorMessage(this.localizer["InvalidCaptcha"]);
                }
            }

            return View(nameof(Index), contactViewModel);
        }
    }
}
