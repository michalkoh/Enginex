using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Data;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Product, Product> mapper;
        private readonly IStringLocalizer<SharedResource> localizer;

        public GetProductQueryHandler(IRepository repository, IMapper<Domain.Entities.Product, Product> mapper, IStringLocalizer<SharedResource> localizer)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.localizer = localizer;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.ProductId);
            if (product is null)
            {
                throw new BusinessException(this.localizer["ProductNotFound", request.ProductId]);
            }

            return this.mapper.Map(product);
        }
    }
}
