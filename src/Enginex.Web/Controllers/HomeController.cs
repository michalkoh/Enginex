using Microsoft.AspNetCore.Mvc;

namespace Enginex.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
