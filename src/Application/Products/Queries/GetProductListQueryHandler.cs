using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Entities;
using Enginex.Domain.Specifications;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Queries
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IReadOnlyList<ProductDto>>
    {
        private readonly IRepository repository;
        private readonly IMapper<Product, ProductDto> mapper;

        public GetProductListQueryHandler(IRepository repository, IMapper<Product, ProductDto> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await this.repository.GetProductsAsync(new SelectedCategorySpecification(request.CategoryId));
            return products.Select(this.mapper.Map).ToList().AsReadOnly();
        }
    }
}
