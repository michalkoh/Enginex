using Enginex.Domain.Data;
using MediatR;
using System.Collections.Generic;

namespace Enginex.Application.Products.Queries
{
    public class GetProductEditListQuery : IRequest<IReadOnlyList<ProductEdit>>
    {
        public GetProductEditListQuery(PageArgument pageArgument)
        {
            PageArgument = pageArgument;
        }

        public PageArgument PageArgument { get; }
    }
}
