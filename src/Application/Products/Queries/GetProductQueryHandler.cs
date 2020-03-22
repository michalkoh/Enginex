using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IRepository repository;
        private readonly IMapper<Product, ProductDto> mapper;

        public GetProductQueryHandler(IRepository repository, IMapper<Product, ProductDto> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.ProductId);
            return this.mapper.Map(product);
        }
    }
}
