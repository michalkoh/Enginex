using Enginex.Application.Categories.Queries;
using System.Collections.Generic;

namespace Enginex.Web.ViewModels
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            Categories = new List<CategoryDto>(0);
        }

        public int? SelectedCategoryId { get; set; }

        public IReadOnlyList<CategoryDto> Categories { get; set; }
    }
}
