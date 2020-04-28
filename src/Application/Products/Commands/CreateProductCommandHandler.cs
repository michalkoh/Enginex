using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Domain.Entities;
using Enginex.Domain.FileService;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IRepository repository;
        private readonly IFileUpload fileUpload;
        private readonly IStringLocalizer<SharedResource> localizer;

        public CreateProductCommandHandler(IRepository repository, IFileUpload fileUpload, IStringLocalizer<SharedResource> localizer)
        {
            this.repository = repository;
            this.fileUpload = fileUpload;
            this.localizer = localizer;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetCategoryAsync(request.CategoryId);
            if (category is null)
            {
                throw new BusinessException(this.localizer["CategoryNotFound", request.CategoryId]);
            }

            var imageFileName = await this.fileUpload.UploadImageAsync(request.Image);
            var product = new Product(request.Name, request.Type, imageFileName, request.Description, category);
            await this.repository.AddProductAsync(product);

            return Unit.Value;
        }
    }
}
