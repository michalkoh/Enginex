using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Commands
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand>
    {
        private readonly IRepository repository;

        public EditCategoryCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetCategoryAsync(request.Id);
            if (category is null)
            {
                throw new BusinessException($"Kategória neexistuje.");
            }

            category.Update(request.Name);
            await this.repository.UpdateCategoryAsync(category);

            return Unit.Value;
        }
    }
}
