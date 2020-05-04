using Enginex.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Serilog;

namespace Enginex.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILogger logger;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var externalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var loginViewModel = new LoginViewModel(returnUrl, externalLogins);
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
        {
            returnUrl ??= Url.Content("~/");

            var externalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var loginViewModel = new LoginViewModel(returnUrl, externalLogins);

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Nastala chyba pri prihlasovaní: {remoteError}");
                return View("Login", loginViewModel);
            }

            var info = await this.signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Nepodarilo sa získať prihlasovacie údaje od externého poskytovateľa.");
                return View("Login", loginViewModel);
            }

            var signInResult = await this.signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                this.logger.Information("Madafaka user signed in.");
                return LocalRedirect(returnUrl);
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            ModelState.AddModelError(string.Empty, $"Prístup pre '{email}' bol zamietnutý.");
            return View("Login", loginViewModel);

            ////if (email != null)
            ////{
            ////    var user = await this.userManager.FindByEmailAsync(email);
            ////    if (user == null)
            ////    {
            ////        user = new IdentityUser
            ////        {
            ////            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
            ////            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
            ////        };

            ////        await this.userManager.CreateAsync(user);
            ////    }

            ////    await this.userManager.AddLoginAsync(user, info);
            ////    await this.signInManager.SignInAsync(user, isPersistent: false);

            ////    return LocalRedirect(returnUrl);
            ////}

            ////ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";

            ////return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
