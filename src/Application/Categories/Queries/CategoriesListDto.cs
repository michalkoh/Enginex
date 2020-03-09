using System.Collections.Generic;
using System.Linq;

namespace Enginex.Application.Categories.Queries
{
    public class CategoriesListDto
    {
        public CategoriesListDto(IEnumerable<CategoryDto> categories, CategoryDto? selectedCategory)
        {
            Categories = categories.ToList();
            SelectedCategory = selectedCategory;
        }

        public IList<CategoryDto> Categories { get; }

        public CategoryDto? SelectedCategory { get; }
    }
}
