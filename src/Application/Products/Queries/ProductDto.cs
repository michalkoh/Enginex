namespace Enginex.Application.Products.Queries
{
    public class ProductDto
    {
        public ProductDto(int id, string name, string type, string? description, string imagePath, int categoryId, string categoryName)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            ImagePath = imagePath;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public static ProductDto Null { get; } = new ProductDto(0, string.Empty, string.Empty, null, string.Empty, 0, string.Empty);

        public int Id { get; }

        public string Name { get; }

        public string Type { get; }

        public string ImagePath { get; }

        public string? Description { get; }

        public int CategoryId { get; }

        public string CategoryName { get; }
    }
}
