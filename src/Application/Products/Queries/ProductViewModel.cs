namespace Enginex.Application.Products.Queries
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            CategoryName = string.Empty;
            Name = string.Empty;
            Type = string.Empty;
            ImagePath = string.Empty;
        }

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string ImagePath { get; set; }

        public string? Description { get; set; }
    }
}
