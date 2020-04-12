using Enginex.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Products.Commands
{
    public class DeleteProductCommandhandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository repository;

        public DeleteProductCommandhandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.Id);
            if (!(product is null))
            {
                await this.repository.DeleteProductAsync(product);
            }

            return Unit.Value;
        }
    }
}
