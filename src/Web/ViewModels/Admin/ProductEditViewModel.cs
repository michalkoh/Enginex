using Enginex.Application.Products.Queries;
using Enginex.Domain;

namespace Enginex.Web.ViewModels.Admin
{
    public class ProductEditViewModel
    {
        public ProductEditViewModel(ProductEdit product)
        {
            Name = product.Name;
            Type = product.Type;
            Description = product.Description;
            ImagePath = product.ImagePath;
            CategoryId = product.CategoryId;
        }

        public ProductEditViewModel()
        {
            Name = LocalString.Empty;
            Type = string.Empty;
            ImagePath = string.Empty;
        }

        public LocalString Name { get; }

        public string Type { get; }

        public LocalString? Description { get; }

        public string ImagePath { get; }

        public int CategoryId { get; }
    }
}
