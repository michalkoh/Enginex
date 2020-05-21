using Enginex.Application.Categories.Queries;
using System.Collections.Generic;

namespace Enginex.Web.ViewModels.Admin
{
    public class CategoryEditListViewModel
    {
        public CategoryEditListViewModel()
        {
            Categories = new List<CategoryEdit>(0);
        }

        public CategoryEditListViewModel(IReadOnlyList<CategoryEdit> categories)
            : this()
        {
            Categories = categories;
            CanCreateCategory = categories.Count < 6;
        }

        public bool CanCreateCategory { get; set; }

        public IReadOnlyList<CategoryEdit> Categories { get; set; }
    }
}
