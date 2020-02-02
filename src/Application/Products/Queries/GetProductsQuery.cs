using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<ProductsViewModel>
    {
        public int? CategoryId { get; }

        public GetProductsQuery(int? categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
