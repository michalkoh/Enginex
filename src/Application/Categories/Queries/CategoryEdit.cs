using Enginex.Domain;

namespace Enginex.Application.Categories.Queries
{
    public class CategoryEdit
    {
        public CategoryEdit(int id, LocalString name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public LocalString Name { get; }
    }
}
