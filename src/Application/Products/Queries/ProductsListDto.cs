using System.Collections.Generic;
using System.Linq;

namespace Enginex.Application.Products.Queries
{
    public class ProductsListDto
    {
        public ProductsListDto(IEnumerable<ProductDto> products)
        {
            Products = products.ToList();
        }

        public IList<ProductDto> Products { get; }
    }
}
