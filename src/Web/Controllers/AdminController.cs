using Enginex.Application.Categories.Queries;
using Enginex.Application.Products.Queries;
using Enginex.Domain.Data;
using Enginex.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private readonly IWebHostEnvironment environment;

        public AdminController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
                await Mediator.Send(productModel.ToCommand(this.environment.WebRootPath));
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
                await Mediator.Send(productModel.ToCommand(this.environment.WebRootPath));
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
            return RedirectToAction(nameof(Categories));
        }
    }
}
