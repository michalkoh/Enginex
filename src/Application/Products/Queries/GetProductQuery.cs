using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public GetProductQuery(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; }
    }
}
