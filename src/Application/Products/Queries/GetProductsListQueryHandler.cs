using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Entities;
using Enginex.Domain.Specifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Queries
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListDto>
    {
        private readonly IRepository repository;
        private readonly IMapper<Product, ProductDto> mapper;

        public GetProductsListQueryHandler(IRepository repository, IMapper<Product, ProductDto> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductsListDto> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await this.repository.GetProductsAsync(new SelectedCategorySpecification(request.CategoryId));
            return new ProductsListDto(products.Select(this.mapper.Map));
        }
    }
}
