using System.Collections.Generic;

namespace Enginex.Application.Categories.Queries.GetCategories
{
    public class CategoriesListViewModel
    {
        public CategoriesListViewModel(IEnumerable<CategoryViewModel> categories)
        {
            Categories = categories;
        }

        private IEnumerable<CategoryViewModel> Categories { get; }
    }
}
