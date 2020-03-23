using Enginex.Domain.Data;
using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductEditListQuery : IRequest<Page<ProductEdit>>
    {
        public GetProductEditListQuery(PageArgument pageArgument)
        {
            PageArgument = pageArgument;
        }

        public PageArgument PageArgument { get; }
    }
}
