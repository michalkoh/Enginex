using Enginex.Application.Products.Queries;
using Enginex.Application.Request.Commands;

namespace Enginex.Web.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel()
        {
            Product = new ProductDto();
            Request = new RequestViewModel();
        }

        public ProductDetailViewModel(ProductDto product)
            : this()
        {
            Product = product;
        }

        public ProductDto Product { get; set; }

        public RequestViewModel Request { get; set; }

        public SendRequestCommand ToCommand()
        {
            return new SendRequestCommand()
            {
                ProductId = Product.Id,
                Email = Request.Email ?? string.Empty,
                Message = Request.Message ?? string.Empty
            };
        }
    }
}
