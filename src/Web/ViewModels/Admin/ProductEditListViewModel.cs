using Enginex.Application.Products.Queries;
using System.Collections.Generic;

namespace Enginex.Web.ViewModels.Admin
{
    public class ProductEditListViewModel
    {
        public ProductEditListViewModel()
        {
            Products = new List<ProductEdit>(0);
            PagingInfo = new PagingInfo();
        }

        public IReadOnlyList<ProductEdit> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
