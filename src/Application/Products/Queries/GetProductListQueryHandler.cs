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
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IReadOnlyList<Product>>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Product, Product> mapper;

        public GetProductListQueryHandler(IRepository repository, IMapper<Domain.Entities.Product, Product> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await this.repository.GetProductsAsync(new ProductsInCategory(request.CategoryId));
            return products.OrderBy(p => p.Name.Slovak).Select(this.mapper.Map).ToList().AsReadOnly();
        }
    }
}
