using Enginex.Application.Request.Commands;

namespace Enginex.Web.ViewModels.Product
{
    public class ProductRequestViewModel
    {
        public ProductRequestViewModel()
        {
            Product = Application.Products.Queries.Product.Null;
            Request = new RequestViewModel();
        }

        public ProductRequestViewModel(Application.Products.Queries.Product product)
            : this()
        {
            Product = product;
            Request = new RequestViewModel() { ProductId = product.Id };
        }

        public Application.Products.Queries.Product Product { get; set; }

        public RequestViewModel Request { get; set; }

        public SendRequestCommand ToCommand(string to, string productUrl)
        {
            return new SendRequestCommand()
            {
                ProductId = Request.ProductId,
                ProductUrl = productUrl,
                From = Request.Email ?? string.Empty,
                To = to,
                Message = Request.Message ?? string.Empty
            };
        }
    }
}
