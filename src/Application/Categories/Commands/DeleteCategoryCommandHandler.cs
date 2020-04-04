using Enginex.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository repository;

        public DeleteCategoryCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetCategoryAsync(request.Id);
            if (!(category is null))
            {
                await this.repository.DeleteCategoryAsync(category);
            }

            return Unit.Value;
        }
    }
}
