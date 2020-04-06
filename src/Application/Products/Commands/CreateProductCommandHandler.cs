using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IRepository repository;

        public CreateProductCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetCategoryAsync(request.CategoryId);
            if (category is null)
            {
                throw new BusinessException($"Kategória s Id: {request.CategoryId} neexistuje.");
            }

            var product = new Product(request.Name, request.Type, request.ImagePath, request.Description, category);
            await this.repository.AddProductAsync(product);

            return Unit.Value;
        }
    }
}
