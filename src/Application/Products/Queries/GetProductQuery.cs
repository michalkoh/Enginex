using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public GetProductQuery(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; }
    }
}
