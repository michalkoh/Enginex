using Enginex.Application.Categories.Queries;
using Enginex.Application.Products.Queries;
using Enginex.Domain.Data;
using Enginex.Infrastructure.VersionInfo;
using Enginex.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Reflection;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private readonly ILogger logger;

        public AdminController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var webAppInfo = WebAppVersionInfo.Load(Assembly.GetExecutingAssembly());
            return View(new WebAppViewModel() { TargetFramework = webAppInfo.TargetFramework });
        }

        public async Task<IActionResult> Products(int? categoryId, int? page)
        {
            var pageArgument = new PageArgument(page ?? 1);
            var productPage = await Mediator.Send(new GetProductEditListQuery(pageArgument, categoryId));
            var categories = await Mediator.Send(new GetCategoryListQuery());
            return View(new ProductEditListViewModel(productPage, pageArgument, categories, categoryId));
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await Mediator.Send(new GetCategoryListQuery());
            return View(new ProductCreateViewModel(categories));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateViewModel productModel)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(productModel.ToCommand());
                ConfirmationMessage("Produkt bol pridaný.");
                this.logger.Information($"New product '{productModel.NameSlovak}' has been successfully created.");
                return RedirectToAction(nameof(Products));
            }

            productModel.Categories = await Mediator.Send(new GetCategoryListQuery());
            return View(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await Mediator.Send(new GetProductEditQuery(id));
            var categories = await Mediator.Send(new GetCategoryListQuery());
            return View(new ProductEditViewModel(product, categories));
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditViewModel productModel)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(productModel.ToCommand());
                ConfirmationMessage("Produkt bol upravený.");
                this.logger.Information($"The product '{productModel.NameSlovak}' has been successfully updated.");
                return RedirectToAction(nameof(Products));
            }

            productModel.Categories = await Mediator.Send(new GetCategoryListQuery());
            return View(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await Mediator.Send(new GetProductEditQuery(id));
            return View(new ProductDeleteViewModel(product));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductDeleteViewModel productModel)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(productModel.ToCommand());
                ConfirmationMessage("Produkt bol zmazaný.");
                this.logger.Information($"The product '{productModel.Name}' has been successfully deleted.");
                return RedirectToAction(nameof(Products));
            }

            return View(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await Mediator.Send(new GetCategoryEditListQuery());
            return View(new CategoryEditListViewModel(categories));
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View(new CategoryCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(categoryModel.ToCommand());
                ConfirmationMessage("Kategória bola pridaná.");
                this.logger.Information($"The category '{categoryModel.NameSlovak}' has been successfully created.");
                return RedirectToAction(nameof(Categories));
            }

            return View(categoryModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await Mediator.Send(new GetCategoryEditQuery(id));
            return View(new CategoryEditViewModel(category));
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryEditViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(categoryModel.ToCommand());
                ConfirmationMessage("Kategória bola upravená.");
                this.logger.Information($"The category '{categoryModel.NameSlovak}' has been successfully updated.");
                return RedirectToAction(nameof(Categories));
            }

            return View(categoryModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await Mediator.Send(new GetCategoryEditQuery(id));
            return View(new CategoryDeleteViewModel(category));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(CategoryDeleteViewModel categoryModel)
        {
            await Mediator.Send(categoryModel.ToCommand());
            ConfirmationMessage("Kategória bola zmazaná.");
            this.logger.Information($"The category '{categoryModel.Name}' has been successfully deleted.");
            return RedirectToAction(nameof(Categories));
        }
    }
}
