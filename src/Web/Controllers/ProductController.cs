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

        public async Task<IActionResult> Detail(int id)
        {
            var product = await Mediator.Send(new GetProductDetailQuery(id));
            var contact = new ContactViewModel()
            {
                Name = "Info k produktu",
            };
            return View(new ProductDetailViewModel(product, contact));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MoreInfo(ProductDetailViewModel detailViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await this.captcha.IsValid(detailViewModel.Contact.CaptchaToken, HttpContext.Connection.RemoteIpAddress.ToString()))
                {
                    var command = detailViewModel.Contact.ToCommand();
                    await Mediator.Send(command);
                    ConfirmationMessage(this.localizer["EmailSent"]);
                    return RedirectToAction(nameof(Detail), detailViewModel.Product.Id);
                }
                else
                {
                    ErrorMessage(this.localizer["InvalidCaptcha"]);
                }
            }

            return View(nameof(Detail), detailViewModel);
        }
    }
}
