using Enginex.Domain.Data;
using Enginex.Domain.FileService;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository repository;
        private readonly IFileUpload fileUpload;

        public DeleteProductCommandHandler(IRepository repository, IFileUpload fileUpload)
        {
            this.repository = repository;
            this.fileUpload = fileUpload;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.Id);
            if (!(product is null))
            {
                this.fileUpload.DeleteImage(product.Image);
                await this.repository.DeleteProductAsync(product);
            }

            return Unit.Value;
        }
    }
}
