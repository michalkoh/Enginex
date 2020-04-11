using Enginex.Application.FileUpload;
using Enginex.Domain;
using MediatR;

namespace Enginex.Application.Products.Commands
{
    public class EditProductCommand : IRequest
    {
        public EditProductCommand(int id, LocalString name, string type, ImageFileUpload image, LocalString description, int categoryId)
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

        public ImageFileUpload? Image { get; }

        public LocalString Description { get; }

        public int CategoryId { get; }
    }
}
