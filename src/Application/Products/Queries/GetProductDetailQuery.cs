using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductDetailQuery : IRequest<ProductViewModel>
    {
        public GetProductDetailQuery(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }
}
