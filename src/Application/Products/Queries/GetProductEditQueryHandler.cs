using System;
using System.Threading;
using System.Threading.Tasks;
using Enginex.Application.Mapping;
using Enginex.Domain.Data;
using MediatR;

namespace Enginex.Application.Products.Queries
{
    public class GetProductEditQueryHandler : IRequestHandler<GetProductEditQuery, ProductEdit>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Product, ProductEdit> mapper;

        public GetProductEditQueryHandler(IRepository repository, IMapper<Domain.Entities.Product, ProductEdit> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductEdit> Handle(GetProductEditQuery request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.ProductId);

            return this.mapper.Map(product);
        }
    }
}
