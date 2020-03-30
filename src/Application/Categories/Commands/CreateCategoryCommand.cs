using Enginex.Domain;
using MediatR;

namespace Enginex.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest
    {
        public CreateCategoryCommand(LocalString name)
        {
            Name = name;
        }

        public LocalString Name { get; }
    }
}
