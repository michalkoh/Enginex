using MediatR;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoriesListQuery : IRequest<CategoriesListViewModel>
    {
        public GetCategoriesListQuery(int? selectedCategoryId)
        {
            SelectedCategoryId = selectedCategoryId;
        }

        public int? SelectedCategoryId { get; }
    }
}
