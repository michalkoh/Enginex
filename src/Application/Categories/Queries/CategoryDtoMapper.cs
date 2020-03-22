using Enginex.Application.Localization;
using Enginex.Application.Mapping;
using Enginex.Domain.Entities;

namespace Enginex.Application.Categories.Queries
{
    internal class CategoryDtoMapper : IMapper<Category, CategoryDto>
    {
        private readonly ICurrentCulture currentCulture;

        public CategoryDtoMapper(ICurrentCulture currentCulture)
        {
            this.currentCulture = currentCulture;
        }

        public CategoryDto Map(Category category)
        {
            return new CategoryDto(category.Id, category.Name.Translate(this.currentCulture));
        }
    }
}
