using Enginex.Application.Products.Queries;
using Enginex.Domain;
using Enginex.Web.ViewModels.Product;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Serilog;

namespace Enginex.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IStringLocalizer<ProductController> localizer;
        private readonly ICaptcha captcha;
        private readonly ILogger logger;

        public ProductController(IStringLocalizer<ProductController> localizer, ICaptcha captcha, ILogger logger)
        {
            this.localizer = localizer;
            this.captcha = captcha;
            this.logger = logger;
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
        public async Task<IActionResult> Detail(int id)
        {
            return View(new ProductRequestViewModel()
            {
                Product = await Mediator.Send(new GetProductQuery(id)),
                Request = new RequestViewModel() { ProductId = id }
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
                    this.logger.Information($"Product request from '{requestViewModel.Request.Email}' has been sent.");
                    return RedirectToAction(nameof(Detail), requestViewModel.Product.Id);
                }
                else
                {
                    this.logger.Error("Failed due to invalid CAPTCHA.");
                    ErrorMessage(this.localizer["InvalidCaptcha"]);
                }
            }

            requestViewModel.Product = await Mediator.Send(new GetProductQuery(requestViewModel.Request.ProductId));
            return View(requestViewModel);
        }
    }
}
