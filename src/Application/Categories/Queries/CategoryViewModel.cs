namespace Enginex.Application.Categories.Queries
{
    public class CategoryViewModel
    {
        public static CategoryViewModel Empty = new CategoryViewModel(string.Empty);
        
        public CategoryViewModel(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
