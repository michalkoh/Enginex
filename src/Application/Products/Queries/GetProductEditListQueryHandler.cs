using Enginex.Application.Mapping;
using Enginex.Domain.Data;
using Enginex.Domain.Specifications;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Queries
{
    public class GetProductEditListQueryHandler : IRequestHandler<GetProductEditListQuery, IReadOnlyList<ProductEdit>>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Product, ProductEdit> mapper;

        public GetProductEditListQueryHandler(IRepository repository, IMapper<Domain.Entities.Product, ProductEdit> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductEdit>> Handle(GetProductEditListQuery request, CancellationToken cancellationToken)
        {
            var products = await this.repository.GetProductsAsync(new AllProducts());
            return products
                .OrderBy(p => p.Name.Slovak)
                .ThenBy(p => p.Id)
                .GetPage(request.PageArgument)
                .Select(this.mapper.Map)
                .ToList()
                .AsReadOnly();
        }
    }
}
