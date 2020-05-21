using Enginex.Domain;

namespace Enginex.Application.Categories.Queries
{
    public class CategoryEdit
    {
        public CategoryEdit(int id, LocalString name, ushort order)
        {
            Id = id;
            Name = name;
            Order = order;
        }

        public int Id { get; }

        public LocalString Name { get; }

        public ushort Order { get; }
    }
}
