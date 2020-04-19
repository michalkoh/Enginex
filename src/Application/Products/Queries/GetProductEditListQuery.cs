using Enginex.Domain.Data;
using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductEditListQuery : IRequest<Page<ProductEdit>>
    {
        public GetProductEditListQuery(PageArgument pageArgument, int? categoryId)
        {
            PageArgument = pageArgument;
            CategoryId = categoryId;
        }

        public PageArgument PageArgument { get; }

        public int? CategoryId { get; }
    }
}
