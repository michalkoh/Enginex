using Enginex.Application.Localization;
using Enginex.Application.Mapping;

namespace Enginex.Application.Categories.Queries
{
    internal class CategoryMapper : IMapper<Domain.Entities.Category, Category>
    {
        private readonly ICurrentCulture currentCulture;

        public CategoryMapper(ICurrentCulture currentCulture)
        {
            this.currentCulture = currentCulture;
        }

        public Category Map(Domain.Entities.Category category)
        {
            return new Category(category.Id, category.Name.Translate(this.currentCulture));
        }
    }
}
