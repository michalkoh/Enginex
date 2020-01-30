using Enginex.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Enginex.Web.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IMediator mediator;

        public CategoryMenu(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await this.mediator.Send(new GetCategoriesListQuery()));
        }
    }
}
