using Enginex.Application.Email.Commands;
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
        public async Task<IActionResult> SendEmail(SendEmailCommandViewModel sendEmailCommandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await this.captcha.IsValid(sendEmailCommandViewModel.CaptchaToken, HttpContext.Connection.RemoteIpAddress.ToString()))
                {
                    var command = new SendEmailCommand()
                    {
                        Email = sendEmailCommandViewModel.Email ?? string.Empty,
                        Name = sendEmailCommandViewModel.Name ?? string.Empty,
                        Subject = sendEmailCommandViewModel.Subject ?? string.Empty,
                        Message = sendEmailCommandViewModel.Message ?? string.Empty
                    };

                    await Mediator.Send(command);
                    TempData["Message"] = this.localizer["EmailSent"].Value;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("CaptchaToken", "The captcha is not valid");
                }
            }

            return View(nameof(Index), sendEmailCommandViewModel);
        }
    }
}
