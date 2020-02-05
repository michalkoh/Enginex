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
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListViewModel>
    {
        private readonly IRepository repository;
        private readonly IMapper<Product, ProductViewModel> mapper;

        public GetProductsListQueryHandler(IRepository repository, IMapper<Product, ProductViewModel> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductsListViewModel> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await this.repository.GetProductsAsync(new SelectedCategorySpecification(request.CategoryId));
            return new ProductsListViewModel(products.Select(this.mapper.Map));
        }
    }
}
