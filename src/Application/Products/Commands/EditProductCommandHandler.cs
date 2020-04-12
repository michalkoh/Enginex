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

            product.Update(request.Name, request.Type, request.Description);

            if (request.Image.UploadPending)
            {
                var image = await request.Image.UploadAsync(product.Image);
                product.ChangeImage(image);
            }

            if (product.Category.Id != request.CategoryId)
            {
                var category = await this.repository.GetCategoryAsync(request.CategoryId);
                if (category is null)
                {
                    throw new BusinessException(this.localizer["CategoryNotFound", request.CategoryId]);
                }

                product.ChangeCategory(category);
            }

            await this.repository.UpdateProductAsync(product);

            return Unit.Value;
        }
    }
}
