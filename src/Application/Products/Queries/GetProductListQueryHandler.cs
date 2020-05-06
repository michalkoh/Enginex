using Enginex.Application.Mapping;
using Enginex.Domain.Data;
using Enginex.Domain.Specifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Queries
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, Page<Product>>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Product, Product> mapper;

        public GetProductListQueryHandler(IRepository repository, IMapper<Domain.Entities.Product, Product> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Page<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = (await this.repository.GetProductsAsync(new ProductsInCategory(request.CategoryId))).ToList();
            return new Page<Product>(
                products
                    .OrderBy(p => p.Name.Slovak)
                    .ThenBy(p => p.Id)
                    .GetPage(request.PageArgument)
                    .Select(this.mapper.Map)
                    .ToList()
                    .AsReadOnly(),
                products.Count);
        }
    }
}
