using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Enginex.Web.Controllers
{
    public class BaseController : Controller
    {
        private IMediator? mediator;

        protected IMediator Mediator => this.mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected void ConfirmationMessage(LocalizedString localizedString)
        {
            TempData["Info"] = localizedString.Value;
        }

        protected void ErrorMessage(LocalizedString localizedString)
        {
            TempData["Error"] = localizedString.Value;
        }
    }
}
