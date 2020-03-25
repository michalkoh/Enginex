using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductEditQuery : IRequest<ProductEdit>
    {
        public GetProductEditQuery(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; }
    }
}
