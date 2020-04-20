using Enginex.Application.Products.Queries;
using Enginex.Domain;
using Enginex.Web.ViewModels.Product;
using Microsoft.AspNetCore.Http.Extensions;
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

        [HttpGet]
        public async Task<IActionResult> List(int? categoryId)
        {
            return View(new ProductListViewModel()
            {
                Products = await Mediator.Send(new GetProductListQuery(categoryId))
            });
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int productId)
        {
            return View(new ProductRequestViewModel()
            {
                Product = await Mediator.Send(new GetProductQuery(productId)),
                Request = new RequestViewModel() { ProductId = productId }
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(ProductRequestViewModel requestViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await this.captcha.IsValid(requestViewModel.Request.CaptchaToken, HttpContext.Connection.RemoteIpAddress.ToString()))
                {
                    var command = requestViewModel.ToCommand(Request.GetDisplayUrl());
                    await Mediator.Send(command);
                    ConfirmationMessage(this.localizer["RequestSent"]);
                    return RedirectToAction(nameof(Detail), requestViewModel.Product.Id);
                }
                else
                {
                    ErrorMessage(this.localizer["InvalidCaptcha"]);
                }
            }

            requestViewModel.Product = await Mediator.Send(new GetProductQuery(requestViewModel.Request.ProductId));
            return View(requestViewModel);
        }
    }
}
