using Enginex.Domain;
using Enginex.Domain.FileUpload;
using MediatR;

namespace Enginex.Application.Products.Commands
{
    public class EditProductCommand : IRequest
    {
        public EditProductCommand(int id, LocalString name, string type, IImageFileUpload image, LocalString description, int categoryId)
        {
            Id = id;
            Name = name;
            Type = type;
            Image = image;
            Description = description;
            CategoryId = categoryId;
        }

        public int Id { get; }

        public LocalString Name { get; }

        public string Type { get; }

        public IImageFileUpload Image { get; }

        public LocalString Description { get; }

        public int CategoryId { get; }
    }
}
