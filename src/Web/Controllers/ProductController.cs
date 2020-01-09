using System;
using Microsoft.AspNetCore.Mvc;

namespace Enginex.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
