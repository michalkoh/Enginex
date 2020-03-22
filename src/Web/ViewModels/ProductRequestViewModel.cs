using System;
using Enginex.Application.Products.Queries;
using Enginex.Application.Request.Commands;

namespace Enginex.Web.ViewModels
{
    public class ProductRequestViewModel
    {
        public ProductRequestViewModel()
        {
            Product = ProductDto.Null;
            Request = new RequestViewModel();
        }

        public ProductDto Product { get; set; }

        public RequestViewModel Request { get; set; }

        public SendRequestCommand ToCommand(string productUrl)
        {
            if (Product is null)
            {
                // TODO what exception?
                throw new InvalidOperationException("Mapping to command failed.");
            }

            return new SendRequestCommand()
            {
                ProductId = Product.Id,
                ProductUrl = productUrl,
                Email = Request.Email ?? string.Empty,
                Message = Request.Message ?? string.Empty
            };
        }
    }
}
