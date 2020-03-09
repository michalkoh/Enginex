using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductsListQuery : IRequest<ProductsListDto>
    {
        public GetProductsListQuery(int? categoryId)
        {
            CategoryId = categoryId;
        }

        public int? CategoryId { get; }
    }
}
