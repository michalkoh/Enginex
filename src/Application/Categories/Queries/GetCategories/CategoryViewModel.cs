using Enginex.Domain.Entities;

namespace Enginex.Application.Categories.Queries.GetCategories
{
    public class CategoryViewModel
    {
        public static CategoryViewModel Empty = new CategoryViewModel(string.Empty);
        
        public CategoryViewModel(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static CategoryViewModel MapFrom(Category category)
        {

        }
    }
}
