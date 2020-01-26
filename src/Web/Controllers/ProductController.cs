using System;
using Microsoft.AspNetCore.Mvc;

namespace Enginex.Web.Controllers
{
    public class ProductController : BaseController
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
