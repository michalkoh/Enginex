using Enginex.Domain;
using Enginex.Domain.Data;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Commands
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IRepository repository;
        private readonly IStringLocalizer<SharedResource> localizer;

        public EditProductCommandHandler(IRepository repository, IStringLocalizer<SharedResource> localizer)
        {
            this.repository = repository;
            this.localizer = localizer;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.Id);
            if (product is null)
            {
                throw new BusinessException(this.localizer["ProductNotFound", request.Id]);
            }

            ////product.Update(request.Name);
            ////await this.repository.UpdateCategoryAsync(product);

            return Unit.Value;
        }
    }
}
