using Enginex.Domain;
using MediatR;

namespace Enginex.Application.Products.Commands
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductCommand(LocalString name, string type, string imagePath, LocalString description, int categoryId)
        {
            Name = name;
            Type = type;
            ImagePath = imagePath;
            Description = description;
            CategoryId = categoryId;
        }

        public LocalString Name { get; }

        public string Type { get; }

        public string ImagePath { get; }

        public LocalString Description { get; }

        public int CategoryId { get; }
    }
}
