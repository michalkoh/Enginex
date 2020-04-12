namespace Enginex.Domain.Entities
{
    public class Category : Entity
    {
        public Category(int id, LocalString name)
            : this(name)
        {
            Id = id;
        }

        public Category(LocalString name)
            : this()
        {
            Name = name;
        }

        private Category()
        {
            Name = LocalString.Empty;
        }

        public static Category Empty { get; } = new Category();

        public LocalString Name { get; private set; }

        public void Update(LocalString name)
        {
            Name = name;
        }
    }
}
