using System.Collections.Generic;

namespace Enginex.Web.ViewModels.Category
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            Categories = new List<Application.Categories.Queries.Category>(0);
        }

        public int? SelectedCategoryId { get; set; }

        public IReadOnlyList<Application.Categories.Queries.Category> Categories { get; set; }
    }
}
