using Enginex.Domain;
using MediatR;

namespace Enginex.Application.Categories.Commands
{
    public class EditCategoryCommand : IRequest
    {
        public EditCategoryCommand(int id, LocalString name, ushort order)
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
