using MediatR;

namespace Enginex.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public DeleteProductCommand(in int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
