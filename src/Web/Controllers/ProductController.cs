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
        private readonly IStringLocalizer<ProductController> localizer;
        private readonly ICaptcha captcha;

        public ProductController(IStringLocalizer<ProductController> localizer, ICaptcha captcha)
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
            return View(new ProductDetailViewModel(await Mediator.Send(new GetProductDetailQuery(id))));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(ProductDetailViewModel detailViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await this.captcha.IsValid(detailViewModel.Request.CaptchaToken, HttpContext.Connection.RemoteIpAddress.ToString()))
                {
                    var command = detailViewModel.ToCommand();
                    await Mediator.Send(command);
                    ConfirmationMessage(this.localizer["RequestSent"]);
                    return RedirectToAction(nameof(Detail), detailViewModel.Product.Id);
                }
                else
                {
                    ErrorMessage(this.localizer["InvalidCaptcha"]);
                }
            }

            return View(detailViewModel);
        }
    }
}
