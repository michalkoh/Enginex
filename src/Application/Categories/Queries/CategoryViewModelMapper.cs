using Enginex.Application.Localization;
using Enginex.Application.Mapping;
using Enginex.Domain.Entities;

namespace Enginex.Application.Categories.Queries
{
    internal class CategoryViewModelMapper : IMapper<Category, CategoryViewModel>
    {
        private readonly ICurrentCulture currentCulture;

        public CategoryViewModelMapper(ICurrentCulture currentCulture)
        {
            this.currentCulture = currentCulture;
        }

        public CategoryViewModel Map(Category category)
        {
            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name.Translate(this.currentCulture)
            };
        }
    }
}
