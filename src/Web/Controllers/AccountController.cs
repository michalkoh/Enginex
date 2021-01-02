using Enginex.Domain;
using Enginex.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEmailSender emailSender;
        private readonly ILogger logger;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IEmailSender emailSender, ILogger logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.emailSender = emailSender;
            this.logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var externalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var loginViewModel = new LoginViewModel(returnUrl, externalLogins);
            return View(loginViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
        {
            this.logger.Information("Trying to authorize...");

            returnUrl ??= Url.Content("~/") ?? string.Empty;

            var externalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var loginViewModel = new LoginViewModel(returnUrl, externalLogins);

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Nastala chyba pri prihlasovaní: {remoteError}");
                this.logger.Error(remoteError);
                return View("Login", loginViewModel);
            }

            var info = await this.signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Nepodarilo sa získať prihlasovacie údaje od externého poskytovateľa.");
                this.logger.Error("Unable to get external login info.");
                return View("Login", loginViewModel);
            }

            var signInResult = await this.signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            if (signInResult.Succeeded)
            {
                this.logger.Information($"User '{email}' has been successfully authorized.");
                return LocalRedirect(returnUrl);
            }

            if (email != null)
            {
                var user = await this.userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        ModelState.AddModelError(string.Empty, $"Emailova adresa '{email}' ešte nebola potvrdená.");
                        this.logger.Warning($"Email address '{email}' has not been confirmed yet.");
                        return View("Login", loginViewModel);
                    }

                    await this.userManager.AddLoginAsync(user, info);
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, $"Prístup pre používateľa '{email}' bol zamietnutý.");
            this.logger.Warning($"User '{email}' has not been authorized.");
            return View("Login", loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await this.userManager.Users.ToListAsync();
            return View(users.AsReadOnly());
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new UserCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                if (userModel.Email != userModel.EmailConfirmed)
                {
                    this.logger.Error($"Email adresses '{userModel.Email}' and '{userModel.EmailConfirmed}' do not match.");
                    ModelState.AddModelError(string.Empty, $"Emailové adresy sa nezhodujú.");
                    return View(userModel);
                }

                var existingUser = await this.userManager.FindByEmailAsync(userModel.Email);
                if (existingUser != null)
                {
                    this.logger.Error($"Administrator '{existingUser.Email}' already exists.");
                    ModelState.AddModelError(string.Empty, $"Administrátor '{existingUser.Email}' už existuje.");
                    return View(userModel);
                }

                var user = new IdentityUser
                {
                    UserName = userModel.Email,
                    Email = userModel.Email
                };

                var result = await this.userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await SendConfirmationMailAsync(user);

                    ConfirmationMessage("Administrátor bol pridaný. Skontrolujte emailovú schránku pre overenie adresy.");
                    this.logger.Information($"New administrator '{userModel.Email}' has been successfully added.");

                    return RedirectToAction(nameof(Users));
                }

                this.logger.Error($"The administrator '{userModel.Email}' could not be added.");
                foreach (var error in result.Errors)
                {
                    this.logger.Error($"{error.Code} {error.Description}");
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(userModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var user = await this.userManager.FindByEmailAsync(email);
            return View(new UserDeleteViewModel(user));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(UserDeleteViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManager.FindByEmailAsync(userModel.Email);
                var currentSignedUser = await this.userManager.GetUserAsync(HttpContext.User);
                if (user.Id == currentSignedUser.Id)
                {
                    this.logger.Information($"The currently signed administrator '{userModel.Email}' cannot remove himself.");
                    ModelState.AddModelError(string.Empty, $"Aktuálne prihlásený administrátor '{userModel.Email}' nemôže byť zmazaný.");
                    return View(userModel);
                }

                var result = await this.userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    ConfirmationMessage("Administrátor bol zmazaný.");
                    this.logger.Information($"The administrator '{userModel.Email}' has been removed.");
                    return RedirectToAction(nameof(Users));
                }

                this.logger.Error($"The administrator '{userModel.Email}' could not be removed.");
                foreach (var error in result.Errors)
                {
                    this.logger.Error($"{error.Code} {error.Description}");
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(userModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                this.logger.Error($"Email confirmation for user '{userId}' with token '{token}' failed.");
                return RedirectToAction("Index", "Home");
            }

            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                this.logger.Error($"Email confirmation for user '{userId}' failed. User not found.");
                ViewBag.ErrorMessage = "Overenie emailovej adresy zlyhalo. Používateľ nebol nájdený.";
                return View("Error");
            }

            var result = await this.userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }

            this.logger.Error(string.Join(' ', result.Errors.Select(e => e.Description)));
            ViewBag.ErrorMessage = "Nepodarilo sa overiť emailovú adresu.";
            return View("Error");
        }

        private async Task SendConfirmationMailAsync(IdentityUser user)
        {
            var token = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

            await this.emailSender.SendEmailAsync(
                user.Email,
                "Potvrdenie emailovej adresy",
                $@"Potvrďte emailovú adresu kliknutím na nasledujúci odkaz: <a href=""{confirmationLink}"">{confirmationLink}</a>");
        }
    }
}
