using MediatR;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoriesListQuery : IRequest<CategoriesListDto>
    {
        public GetCategoriesListQuery(int? selectedCategoryId)
        {
            SelectedCategoryId = selectedCategoryId;
        }

        public int? SelectedCategoryId { get; }
    }
}
