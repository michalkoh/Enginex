using Enginex.Domain;

namespace Enginex.Application.Products.Queries
{
    public class ProductEdit
    {
        public ProductEdit(int id, LocalString name, string type, LocalString description, string image, int categoryId)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            Image = image;
            CategoryId = categoryId;
        }

        public int Id { get; }

        public LocalString Name { get; }

        public string Type { get; }

        public LocalString Description { get; }

        public string Image { get; }

        public int CategoryId { get; }
    }
}
