using Enginex.Application.Mapping;

namespace Enginex.Application.Categories.Queries
{
    internal class CategoryEditMapper : IMapper<Domain.Entities.Category, CategoryEdit>
    {
        public CategoryEdit Map(Domain.Entities.Category category)
        {
            return new CategoryEdit(category.Id, category.Name);
        }
    }
}
