using Enginex.Domain;
using MediatR;

namespace Enginex.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest
    {
        public CreateCategoryCommand(LocalString name, ushort order)
        {
            Name = name;
            Order = order;
        }

        public LocalString Name { get; }

        public ushort Order { get; }
    }
}
