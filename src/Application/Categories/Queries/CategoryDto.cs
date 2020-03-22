namespace Enginex.Application.Categories.Queries
{
    public class CategoryDto
    {
        public CategoryDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}
