using Enginex.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Enginex.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            var consentFeature = ControllerContext.HttpContext.Features.Get<ITrackingConsentFeature>();
            if (consentFeature?.HasConsent == true)
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

                return LocalRedirect(returnUrl);
            }
            else
            {
                return LocalRedirect(returnUrl.ReplaceQueryStringParameter("culture", culture));
            }
        }
    }
}
