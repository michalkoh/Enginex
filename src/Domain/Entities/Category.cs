namespace Enginex.Domain.Entities
{
    public class Category : Entity
    {
        public Category(int id, string nameSk, string nameEn) : this()
        {
            NameSk = nameSk;
            NameEn = nameEn;
        }

        private Category()
        {
        }

        public string NameSk { get; }

        public string NameEn { get; }
    }
}
