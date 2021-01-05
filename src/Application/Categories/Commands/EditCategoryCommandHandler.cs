using System.Linq;
using Enginex.Domain;
using Enginex.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Enginex.Application.Categories.Commands
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand>
    {
        private readonly IRepository repository;
        private readonly IStringLocalizer<SharedResource> localizer;

        public EditCategoryCommandHandler(IRepository repository, IStringLocalizer<SharedResource> localizer)
        {
            this.repository = repository;
            this.localizer = localizer;
        }

        public async Task<Unit> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetCategoryAsync(request.Id);
            if (category is null)
            {
                throw new BusinessException(this.localizer["CategoryNotFound", request.Id]);
            }

            var categories = await this.repository.GetCategoriesAsync();
            if (categories.Any(c => request.Order == c.Order && request.Id != c.Id))
            {
                throw new BusinessException(this.localizer["CategoryOrderMustBeUnique"]);
            }

            category.Update(request.Name, request.Order);
            await this.repository.UpdateCategoryAsync(category);

            return Unit.Value;
        }
    }
}
