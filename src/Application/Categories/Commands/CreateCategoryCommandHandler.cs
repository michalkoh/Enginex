using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private const int CategoriesMaxCount = 5;

        private readonly IRepository repository;

        public CreateCategoryCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            if (categories.Count() == CategoriesMaxCount)
            {
                throw new BusinessException($"Maximálny povolený počet kategórií je {CategoriesMaxCount}.");
            }

            var category = new Category(request.Name);
            await this.repository.AddCategoryAsync(category);

            return Unit.Value;
        }
    }
}
