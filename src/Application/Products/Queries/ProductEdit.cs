using Enginex.Domain;

namespace Enginex.Application.Products.Queries
{
    public class ProductEdit
    {
        public ProductEdit(int id, LocalString name, string type, LocalString? description, string imagePath, int categoryId)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            ImagePath = imagePath;
            CategoryId = categoryId;
        }

        public int Id { get; }

        public LocalString Name { get; }

        public string Type { get; }

        public LocalString? Description { get; }

        public string ImagePath { get; }

        public int CategoryId { get; }
    }
}
