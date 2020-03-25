using Enginex.Application.Products.Queries;
using Enginex.Domain.Data;
using Enginex.Web.ViewModels;
using Enginex.Web.ViewModels.Admin;
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
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id.HasValue)
            {
                var product = await Mediator.Send(new GetProductEditQuery(id.Value));
                return View(new ProductEditViewModel(product));
            }

            return View(new ProductEditViewModel());
        }
    }
}
