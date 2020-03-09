using Enginex.Application.Products.Queries;
using Enginex.Domain;
using Enginex.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IStringLocalizer<ContactController> localizer;
        private readonly ICaptcha captcha;

        public ProductController(IStringLocalizer<ContactController> localizer, ICaptcha captcha)
        {
            this.localizer = localizer;
            this.captcha = captcha;
        }

        public async Task<IActionResult> List(int? categoryId)
        {
            return View(await Mediator.Send(new GetProductsListQuery(categoryId)));
        }

        public async Task<IActionResult> Detail(int id, ProductViewModel productViewModel)
        {
            var product = await Mediator.Send(new GetProductDetailQuery(id));
            return View(new ProductViewModel(product, new ContactViewModel()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await this.captcha.IsValid(productViewModel.Contact.CaptchaToken, HttpContext.Connection.RemoteIpAddress.ToString()))
                {
                    var command = productViewModel.Contact.ToCommand();
                    await Mediator.Send(command);
                    ConfirmationMessage(this.localizer["EmailSent"]);
                    return RedirectToAction(nameof(Detail));
                }
                else
                {
                    ErrorMessage(this.localizer["InvalidCaptcha"]);
                }
            }

            return View(nameof(Detail), productViewModel);
        }
    }
}
