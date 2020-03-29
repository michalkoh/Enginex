using Enginex.Web.ViewModels.Category;

namespace Enginex.Web.ViewModels.Admin
{
    public class ProductEditViewModel
    {
        public ProductEditViewModel()
        {
            NameSlovak = string.Empty;
            NameEnglish = string.Empty;
            Type = string.Empty;
            DescriptionSlovak = string.Empty;
            DescriptionEnglish = string.Empty;
            ImagePath = string.Empty;
            CategoryViewModel = new CategoryListViewModel();
        }

        public int Id { get; set; }

        public string NameSlovak { get; set; }

        public string NameEnglish { get; set; }

        public string Type { get; set; }

        public string DescriptionSlovak { get; set; }

        public string DescriptionEnglish { get; set; }

        public string ImagePath { get; set; }

        public CategoryListViewModel CategoryViewModel { get; set; }
    }
}
