﻿using Enginex.Application.Products.Queries;
using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Infrastructure.Email;
using Enginex.Web.ViewModels.Product;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Serilog;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IStringLocalizer<ProductController> localizer;
        private readonly ICaptcha captcha;
        private readonly IOptions<EnginexEmailSettings> enginexEmail;
        private readonly ILogger logger;

        public ProductController(IStringLocalizer<ProductController> localizer, ICaptcha captcha, IOptions<EnginexEmailSettings> enginexEmail, ILogger logger)
        {
            this.localizer = localizer;
            this.captcha = captcha;
            this.enginexEmail = enginexEmail;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> List(int? categoryId, int? page)
        {
            var pageArgument = new PageArgument(page ?? 1, 12);
            var productPage = await Mediator.Send(new GetProductListQuery(pageArgument, categoryId));
            return View(new ProductListViewModel(productPage, pageArgument));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            return View(new ProductRequestViewModel(await Mediator.Send(new GetProductQuery(id))));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(ProductRequestViewModel requestViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await this.captcha.IsValid(requestViewModel.Request.CaptchaToken, HttpContext.Connection.RemoteIpAddress?.ToString()))
                {
                    var command = requestViewModel.ToCommand(this.enginexEmail.Value.Email, Request.GetDisplayUrl());
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
