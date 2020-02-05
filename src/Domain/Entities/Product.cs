namespace Enginex.Domain.Entities
{
    public class Product : Entity
    {
        public Product(int id, int categoryId, string nameSk, string nameEn, string type, string imagePath) : this()
        {
            Id = id;
            CategoryId = categoryId;
            NameSk = nameSk;
            NameEn = nameEn;
            Type = type;
            ImagePath = imagePath;
        }

        public Product(int id, int categoryId, string nameSk, string nameEn, string type, string imagePath, string descriptionSk, string descriptionEn) 
            : this(id, categoryId, nameSk, nameEn, type, imagePath)
        {
            DescriptionSk = descriptionSk;
            DescriptionEn = descriptionEn;
        }

        private Product()
        {
        }

        public int CategoryId { get; }

        public string NameSk { get; }

        public string NameEn { get; }

        public string Type { get; }

        public string? DescriptionSk { get; }

        public string? DescriptionEn { get; }

        public string ImagePath { get; }
    }
}
