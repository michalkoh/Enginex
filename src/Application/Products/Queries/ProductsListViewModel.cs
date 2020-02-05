using System.Collections.Generic;
using System.Linq;

namespace Enginex.Application.Products.Queries
{
    public class ProductsListViewModel
    {
        public ProductsListViewModel(IEnumerable<ProductViewModel> products)
        {
            Products = products.ToList();
        }

        public IList<ProductViewModel> Products { get; }
    }
}
