namespace Enginex.Domain.Entities
{
    public class Category : Entity
    {
        public Category(LocalString name, ushort order)
            : this()
        {
            Name = name;
            Order = order;
        }

        private Category()
        {
            Name = LocalString.Empty;
        }

        public static Category Empty { get; } = new Category();

        public LocalString Name { get; private set; }

        public ushort Order { get; private set; }

        public void Update(LocalString name, ushort order)
        {
            Name = name;
            Order = order;
        }
    }
}
