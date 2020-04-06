namespace Enginex.Domain.Entities
{
    public class Product : Entity
    {
        public Product(int id, LocalString name, string type, string imagePath, LocalString description, Category category)
            : this(name, type, imagePath, description, category)
        {
            Id = id;
        }

        public Product(LocalString name, string type, string imagePath, LocalString description, Category category)
            : this()
        {
            Name = name;
            Type = type;
            ImagePath = imagePath;
            Description = description;
            Category = category;
        }

        private Product()
        {
            Name = LocalString.Empty;
            Type = string.Empty;
            ImagePath = string.Empty;
            Description = LocalString.Empty;
            Category = Category.Empty;
        }

        public LocalString Name { get; private set; }

        public string Type { get; private set; }

        public LocalString Description { get; private set; }

        public string ImagePath { get; private set; }

        public Category Category { get; private set; }
    }
}
