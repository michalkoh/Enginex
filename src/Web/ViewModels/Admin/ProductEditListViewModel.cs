using Enginex.Application.Products.Queries;
using Enginex.Domain.Data;
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

        public ProductEditListViewModel(Page<ProductEdit> productPage, PageArgument pageArgument)
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

        public IReadOnlyList<ProductEdit> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
