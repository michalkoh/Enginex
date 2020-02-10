using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Queries
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductViewModel>
    {
        private readonly IRepository repository;
        private readonly IMapper<Product, ProductViewModel> mapper;

        public GetProductDetailQueryHandler(IRepository repository, IMapper<Product, ProductViewModel> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.ProductId);
            return this.mapper.Map(product);
        }
    }
}
