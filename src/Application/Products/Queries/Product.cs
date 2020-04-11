namespace Enginex.Application.Products.Queries
{
    public class Product
    {
        public Product(int id, string name, string type, string? description, string image, int categoryId, string categoryName)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            Image = image;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public static Product Null { get; } = new Product(0, string.Empty, string.Empty, null, string.Empty, 0, string.Empty);

        public int Id { get; }

        public string Name { get; }

        public string Type { get; }

        public string Image { get; }

        public string? Description { get; }

        public int CategoryId { get; }

        public string CategoryName { get; }
    }
}
