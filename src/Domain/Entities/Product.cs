namespace Enginex.Domain.Entities
{
    public class Product : Entity
    {
        public Product(int id, LocalString name, string type, string image, LocalString description, Category category)
            : this(name, type, image, description, category)
        {
            Id = id;
        }

        public Product(LocalString name, string type, string image, LocalString description, Category category)
            : this()
        {
            Name = name;
            Type = type;
            Image = image;
            Description = description;
            Category = category;
        }

        private Product()
        {
            Name = LocalString.Empty;
            Type = string.Empty;
            Image = string.Empty;
            Description = LocalString.Empty;
            Category = Category.Empty;
        }

        public LocalString Name { get; private set; }

        public string Type { get; private set; }

        public LocalString Description { get; private set; }

        public string Image { get; private set; }

        public Category Category { get; private set; }
    }
}
