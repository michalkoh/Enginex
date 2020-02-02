namespace Enginex.Application.Products.Queries
{
    public class ProductViewModel
    {
        public ProductViewModel(int id, string name, string type, string? description)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
        }

        public int Id { get; set; }

        public string Name { get; }

        public string Type { get; }

        public string? Description { get; }
    }
}
