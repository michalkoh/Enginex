using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;

namespace Enginex.Web.Controllers
{
    public class BaseController : Controller
    {
        private IMediator? mediator;

        protected IMediator Mediator => this.mediator ??= HttpContext.RequestServices.GetService<IMediator>() ?? throw new InvalidOperationException();

        protected void ConfirmationMessage(LocalizedString localizedMessage)
        {
            ConfirmationMessage(localizedMessage.Value);
        }

        protected void ConfirmationMessage(string message)
        {
            TempData["Info"] = message;
        }

        protected void ErrorMessage(LocalizedString localizedError)
        {
            ErrorMessage(localizedError.Value);
        }

        protected void ErrorMessage(string error)
        {
            TempData["Error"] = error;
        }
    }
}
