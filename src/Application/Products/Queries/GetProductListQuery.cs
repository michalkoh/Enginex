using System.Collections.Generic;
using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductListQuery : IRequest<IReadOnlyList<ProductDto>>
    {
        public GetProductListQuery(int? categoryId)
        {
            CategoryId = categoryId;
        }

        public int? CategoryId { get; }
    }
}
