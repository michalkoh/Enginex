namespace Enginex.Domain.Entities
{
    public class Category : Entity
    {
        public Category(int id, LocalString name)
            : this()
        {
            Id = id;
            Name = name;
        }

        private Category()
        {
            Name = LocalString.Empty;
        }

        public static Category Empty { get; } = new Category();

        public LocalString Name { get; }
    }
}
