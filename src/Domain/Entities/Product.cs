namespace Enginex.Domain.Entities
{
    public class Product : Entity
    {
        public Product(int id, LocalString name, string type, string imagePath, Category category)
            : this()
        {
            Id = id;
            Name = name;
            Type = type;
            ImagePath = imagePath;
            Category = category;
        }

        public Product(int id, LocalString name, string type, string imagePath, Category category, LocalString description)
            : this(id, name, type, imagePath, category)
        {
            Description = description;
        }

        private Product()
        {
            Id = 0;
            Name = LocalString.Empty;
            Type = string.Empty;
            ImagePath = string.Empty;
            Description = LocalString.Empty;
            Category = Category.Empty;
        }

        public LocalString Name { get; }

        public string Type { get; }

        public LocalString? Description { get; }

        public string ImagePath { get; }

        public Category Category { get; }
    }
}
