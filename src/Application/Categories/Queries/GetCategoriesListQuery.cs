using MediatR;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoriesListQuery : IRequest<CategoriesListViewModel>
    {
        public int? SelectedCategoryId { get; }

        public GetCategoriesListQuery(int? selectedCategoryId)
        {
            SelectedCategoryId = selectedCategoryId;
        }
    }
}
