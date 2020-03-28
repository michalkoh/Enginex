using Enginex.Domain;
using Enginex.Web.ViewModels.Category;

namespace Enginex.Web.ViewModels.Admin
{
    public class ProductEditViewModel
    {
        public ProductEditViewModel()
        {
            Name = LocalString.Empty;
            Type = string.Empty;
            Description = LocalString.Empty;
            ImagePath = string.Empty;
            CategoryViewModel = new CategoryListViewModel();
        }

        public int Id { get; set; }

        public LocalString Name { get; set; }

        public string Type { get; set; }

        public LocalString Description { get; set; }

        public string ImagePath { get; set; }

        public CategoryListViewModel CategoryViewModel { get; set; }
    }
}
