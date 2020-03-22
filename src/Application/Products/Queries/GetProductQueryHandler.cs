using Enginex.Application.Mapping;
using Enginex.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Product, Product> mapper;

        public GetProductQueryHandler(IRepository repository, IMapper<Domain.Entities.Product, Product> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.ProductId);
            return this.mapper.Map(product);
        }
    }
}
