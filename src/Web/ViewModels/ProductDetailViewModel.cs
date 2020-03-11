using Enginex.Application.Products.Queries;

namespace Enginex.Web.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel()
        {
            Product = new ProductDto();
            Contact = new ContactViewModel();
        }

        public ProductDetailViewModel(ProductDto product, ContactViewModel contact)
        {
            Product = product;
            Contact = contact;
        }

        public ProductDto Product { get; set; }

        public ContactViewModel Contact { get; set; }
    }
}
