namespace Enginex.Domain.Entities
{
    public class Product : Entity
    {
        public Product(int id, string nameSk, string nameEn, string type) : this()
        {
            Id = id;
            NameSk = nameSk;
            NameEn = nameEn;
            Type = type;
        }

        public Product(int id, string nameSk, string nameEn, string type, string descriptionSk, string descriptionEn) 
            : this(id, nameSk, nameEn, type)
        {
            DescriptionSk = descriptionSk;
            DescriptionEn = descriptionEn;
        }

        private Product()
        {
        }

        public string NameSk { get; }

        public string NameEn { get; }

        public string Type { get; }

        public string? DescriptionSk { get; }

        public string? DescriptionEn { get; }
    }
}
