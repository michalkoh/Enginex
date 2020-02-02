using System.Collections.Generic;

namespace Enginex.Application.Products.Queries
{
    public class ProductsViewModel
    {
        public ProductsViewModel(IEnumerable<ProductViewModel> products)
        {
            Products = products;
        }

        public IEnumerable<ProductViewModel> Products { get; }
    }
}
