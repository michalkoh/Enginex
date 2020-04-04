using MediatR;

namespace Enginex.Application.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
