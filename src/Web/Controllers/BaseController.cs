using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Enginex.Web.Controllers
{
    public class BaseController : Controller
    {
        private IMediator? mediator;

        protected IMediator Mediator => this.mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
