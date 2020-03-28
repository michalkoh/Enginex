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
                Name = product.Name,
                Type = product.Type,
                Description = product.Description,
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
            await Task.Delay(500);
            return View(new ProductEditViewModel()
            {
                CategoryViewModel = new CategoryListViewModel()
                {
                    Categories = categories,
                    SelectedCategoryId = productEditViewModel.CategoryViewModel.SelectedCategoryId
                }
            });
        }
    }
}
