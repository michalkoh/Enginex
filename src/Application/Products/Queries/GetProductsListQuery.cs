using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductsListQuery : IRequest<ProductsListViewModel>
    {
        public GetProductsListQuery(int? categoryId)
        {
            CategoryId = categoryId;
        }

        public int? CategoryId { get; }
    }
}
