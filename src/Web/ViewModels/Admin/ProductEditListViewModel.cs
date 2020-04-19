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
            Categories = new List<Application.Categories.Queries.Category>(0);
        }

        public ProductEditListViewModel(Page<ProductEdit> productPage, PageArgument pageArgument, IReadOnlyList<Application.Categories.Queries.Category> categories, int? selectedCategoryId)
            : this()
        {
            Products = productPage.Items;
            PagingInfo = new PagingInfo
            {
                CurrentPage = pageArgument.Page,
                ItemsPerPage = pageArgument.Size,
                TotalCount = productPage.TotalCount
            };
            Categories = categories;
            SelectedCategoryId = selectedCategoryId;
        }

        public int? SelectedCategoryId { get; set; }

        public IReadOnlyList<Application.Categories.Queries.Category> Categories { get; set; }

        public IReadOnlyList<ProductEdit> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
