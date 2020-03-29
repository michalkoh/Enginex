using MediatR;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoryEditQuery : IRequest<CategoryEdit>
    {
        public GetCategoryEditQuery(int categoryId)
        {
            CategoryId = categoryId;
        }

        public int CategoryId { get; }
    }
}
