using Enginex.Application.Products.Queries;

namespace Enginex.Web.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Product = new ProductDto();
            Contact = new ContactViewModel();
        }

        public ProductViewModel(ProductDto product, ContactViewModel contact)
        {
            Product = product;
            Contact = contact;
        }

        public ProductDto Product { get; set; }

        public ContactViewModel Contact { get; set; }
    }
}
