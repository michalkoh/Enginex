using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductsViewModel>
    {
        private readonly IRepository repository;
        private readonly IMapper<Product, ProductViewModel> mapper;

        public GetProductsQueryHandler(IRepository repository, IMapper<Product, ProductViewModel> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task<ProductsViewModel> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ProductsViewModel(Enumerable.Empty<ProductViewModel>()));
        }
    }
}
