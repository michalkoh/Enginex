using Enginex.Application.Products.Queries;
using Enginex.Domain.Data;
using Enginex.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    public class AdminController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Products(int? categoryId)
        {
            var pageArgument = new PageArgument(1);
            return View(new ProductEditListViewModel()
            {
                Products = await Mediator.Send(new GetProductEditListQuery(pageArgument))
            });
        }
    }
}
