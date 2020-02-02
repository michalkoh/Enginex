using MediatR;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<CategoriesViewModel>
    {
        public int? SelectedCategoryId { get; }

        public GetCategoriesQuery(int? selectedCategoryId)
        {
            SelectedCategoryId = selectedCategoryId;
        }
    }
}
