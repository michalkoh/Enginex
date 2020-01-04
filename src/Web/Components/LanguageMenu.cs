using System.Linq;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Enginex.Web.Components
{
    public class LanguageMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = CookieRequestCultureProvider.ParseCookieValue(Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]);
            var currentCulture = "sk";
            if (result != null && result.Cultures.Any())
            {
                var culture = result.Cultures.First();
                if (culture.HasValue)
                {
                    currentCulture = culture.Value;
                }
            }
            else if (HttpContext.Request.Query.ContainsKey("culture"))
            {
                currentCulture = HttpContext.Request.Query["culture"];
            }

            ViewBag.CurrentCulture = currentCulture;
            return View();
        }
    }
}
