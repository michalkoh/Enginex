namespace Enginex.Application.Products.Queries
{
    public class ProductViewModel
    {
        public ProductViewModel(int id, string name, string type, string imagePath, string? description)
        {
            Id = id;
            Name = name;
            Type = type;
            ImagePath = imagePath;
            Description = description;
        }

        public int Id { get; set; }

        public string Name { get; }

        public string Type { get; }

        public string ImagePath { get; }

        public string? Description { get; }
    }
}
