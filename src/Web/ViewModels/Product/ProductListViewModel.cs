using System.Collections.Generic;

namespace Enginex.Web.ViewModels.Product
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            Products = new List<Application.Products.Queries.Product>(0);
        }

        public IReadOnlyList<Application.Products.Queries.Product> Products { get; set; }
    }
}
