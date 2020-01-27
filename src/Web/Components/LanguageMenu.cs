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

            ViewBag.CurrentCulture = currentCulture;
            return View();
        }
    }
}
