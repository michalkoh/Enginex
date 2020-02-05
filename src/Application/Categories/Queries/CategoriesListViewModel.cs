using System.Collections.Generic;
using System.Linq;

namespace Enginex.Application.Categories.Queries
{
    public class CategoriesListViewModel
    {
        public CategoriesListViewModel(IEnumerable<CategoryViewModel> categories, CategoryViewModel? selectedCategory)
        {
            Categories = categories.ToList();
            SelectedCategory = selectedCategory;
        }

        public IList<CategoryViewModel> Categories { get; }

        public CategoryViewModel? SelectedCategory { get; }
    }
}
