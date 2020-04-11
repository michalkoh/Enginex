using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Enginex.Application.Products.Queries
{
    public class GetProductEditQueryHandler : IRequestHandler<GetProductEditQuery, ProductEdit>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Product, ProductEdit> mapper;
        private readonly IStringLocalizer<SharedResource> localizer;

        public GetProductEditQueryHandler(IRepository repository, IMapper<Domain.Entities.Product, ProductEdit> mapper, IStringLocalizer<SharedResource> localizer)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.localizer = localizer;
        }

        public async Task<ProductEdit> Handle(GetProductEditQuery request, CancellationToken cancellationToken)
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
