using Enginex.Domain.Data;
using System.Collections.Generic;

namespace Enginex.Web.ViewModels.Product
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            Products = new List<Application.Products.Queries.Product>(0);
            PagingInfo = new PagingInfo();
        }

        public ProductListViewModel(Page<Application.Products.Queries.Product> productPage, PageArgument pageArgument)
            : this()
        {
            Products = productPage.Items;
            PagingInfo = new PagingInfo
            {
                CurrentPage = pageArgument.Page,
                ItemsPerPage = pageArgument.Size,
                TotalCount = productPage.TotalCount
            };
        }

        public IReadOnlyList<Application.Products.Queries.Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
