using Enginex.Application.Categories.Queries;
using Enginex.Application.Products.Queries;
using Enginex.Domain.Data;
using Enginex.Web.ViewModels.Admin;
using Enginex.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    public class AdminController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Products(int? categoryId, int? page)
        {
            var pageArgument = new PageArgument(page ?? 1);
            var productPage = await Mediator.Send(new GetProductEditListQuery(pageArgument));
            return View(new ProductEditListViewModel(productPage, pageArgument));
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await Mediator.Send(new GetProductEditQuery(id));
            var categories = await Mediator.Send(new GetCategoryListQuery());
            return View(new ProductEditViewModel(product, categories));
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditViewModel productEditViewModel)
        {
            var categories = await Mediator.Send(new GetCategoryListQuery());
            return View(new ProductEditViewModel()
            {
                CategoryViewModel = new CategoryListViewModel()
                {
                    Categories = categories,
                    SelectedCategoryId = productEditViewModel.CategoryViewModel.SelectedCategoryId
                }
            });
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
            return View(new CategoryEditViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryEditViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(categoryModel.ToCreateCommand());
                return RedirectToAction(nameof(Categories));
            }

            return View();
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
                await Mediator.Send(categoryModel.ToEditCommand());
                return RedirectToAction(nameof(Categories));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await Mediator.Send(new GetCategoryEditQuery(id));
            return View(new CategoryEditViewModel(category));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(CategoryEditViewModel categoryModel)
        {
            await Mediator.Send(categoryModel.ToDeleteCommand());
            return RedirectToAction(nameof(Categories));
        }
    }
}
