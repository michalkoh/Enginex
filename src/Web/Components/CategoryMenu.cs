using Enginex.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Enginex.Web.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IRepository repository;

        public CategoryMenu(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await this.repository.GetCategoriesAsync();
            return View(categories.Select(c => c.NameSk));
        }
    }
}
