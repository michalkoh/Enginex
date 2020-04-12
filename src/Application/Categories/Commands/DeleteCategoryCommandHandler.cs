using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Domain.Specifications;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository repository;
        private readonly IStringLocalizer<SharedResource> localizer;

        public DeleteCategoryCommandHandler(IRepository repository, IStringLocalizer<SharedResource> localizer)
        {
            this.repository = repository;
            this.localizer = localizer;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetCategoryAsync(request.Id);
            var products = await this.repository.GetProductsAsync(new ProductsInCategory(request.Id));
            if (products.Any())
            {
                throw new BusinessException(this.localizer["CategoryContainsProducts"]);
            }

            if (!(category is null))
            {
                await this.repository.DeleteCategoryAsync(category);
            }

            return Unit.Value;
        }
    }
}
