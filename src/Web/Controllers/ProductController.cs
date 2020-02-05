using Enginex.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    public class ProductController : BaseController
    {
        public async Task<IActionResult> List(int? categoryId)
        {
            return View(await Mediator.Send(new GetProductsListQuery(categoryId)));
        }

        public async Task<IActionResult> Detail(int id)
        {
            return View(await Mediator.Send(new GetProductDetailQuery(id)));
        }
    }
}
