using System.Collections.Generic;

namespace Enginex.Application.Categories.Queries.GetCategories
{
    public class CategoriesListViewModel
    {
        public CategoriesListViewModel(IEnumerable<CategoryViewModel> categories)
        {
            Categories = categories;
        }

        public CategoryViewModel SelectedCategory { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; }
    }
}
