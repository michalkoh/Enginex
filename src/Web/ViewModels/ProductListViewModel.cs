using Enginex.Application.Products.Queries;
using System.Collections.Generic;

namespace Enginex.Web.ViewModels
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            Products = new List<ProductDto>(0);
        }

        public IReadOnlyList<ProductDto> Products { get; set; }
    }
}
