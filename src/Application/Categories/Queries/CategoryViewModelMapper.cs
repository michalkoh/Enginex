using Enginex.Application.Localization;
using Enginex.Application.Mapping;
using Enginex.Domain.Entities;

namespace Enginex.Application.Categories.Queries
{
    internal class CategoryViewModelMapper : LocalizableMapperBase<Category>, IMapper<Category, CategoryViewModel>
    {
        public CategoryViewModelMapper(ICurrentCulture currentCulture) : base(currentCulture)
        {
        }

        public CategoryViewModel Map(Category category)
        {
            return new CategoryViewModel(category.Id, MapWithTranslation(category, c => c.NameSk, c => c.NameEn));
        }
    }
}
