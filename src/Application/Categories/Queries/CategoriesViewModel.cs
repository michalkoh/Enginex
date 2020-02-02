using System.Collections.Generic;

namespace Enginex.Application.Categories.Queries
{
    public class CategoriesViewModel
    {
        public CategoriesViewModel(IEnumerable<CategoryViewModel> categories, CategoryViewModel? selectedCategory)
        {
            Categories = categories;
            SelectedCategory = selectedCategory;
        }

        public IEnumerable<CategoryViewModel> Categories { get; }

        public CategoryViewModel? SelectedCategory { get; }
    }
}
