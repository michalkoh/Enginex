using Enginex.Domain;
using MediatR;

namespace Enginex.Application.Categories.Commands
{
    public class EditCategoryCommand : IRequest
    {
        public EditCategoryCommand(int id, LocalString name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public LocalString Name { get; }
    }
}
