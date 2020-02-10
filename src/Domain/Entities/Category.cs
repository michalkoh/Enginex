namespace Enginex.Domain.Entities
{
    public class Category : Entity
    {
        public Category(int id, LocalString name) : this()
        {
            Id = id;
            Name = name;
        }

        private Category()
        {
        }

        public LocalString Name { get; }
    }
}
