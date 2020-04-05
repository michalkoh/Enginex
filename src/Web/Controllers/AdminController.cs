using System;
using Enginex.Application.Categories.Queries;
using Enginex.Application.Products.Queries;
using Enginex.Domain.Data;
using Enginex.Web.ViewModels;
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
            return View(new ProductEditListViewModel()
            {
                Products = productPage.Items,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageArgument.Page,
                    ItemsPerPage = pageArgument.Size,
                    TotalCount = productPage.TotalCount
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await Mediator.Send(new GetProductEditQuery(id));
            var categories = await Mediator.Send(new GetCategoryListQuery());
            return View(new ProductEditViewModel()
            {
                Id = product.Id,
                NameSlovak = product.Name.Slovak,
                NameEnglish = product.Name.English,
                Type = product.Type,
                DescriptionSlovak = product.Description.Slovak,
                DescriptionEnglish = product.Description.English,
                ImagePath = product.ImagePath,
                CategoryViewModel = new CategoryListViewModel()
                {
                    Categories = categories,
                    SelectedCategoryId = product.CategoryId
                }
            });
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
            return View(await Mediator.Send(new GetCategoryEditListQuery()));
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
            return View(new CategoryEditViewModel()
            {
                Id = category.Id,
                NameSlovak = category.Name.Slovak,
                NameEnglish = category.Name.English
            });
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
            return View(new CategoryEditViewModel()
            {
                Id = category.Id,
                NameSlovak = category.Name.Slovak,
                NameEnglish = category.Name.English
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(CategoryEditViewModel categoryModel)
        {
            await Mediator.Send(categoryModel.ToDeleteCommand());
            return RedirectToAction(nameof(Categories));
        }
    }
}
