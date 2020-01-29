using Enginex.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, CategoriesListViewModel>
    {
        private readonly IRepository repository;

        public GetCategoriesListQueryHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CategoriesListViewModel> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            var categoriesViewModels = categories.Select(c => new CategoryViewModel() {Name = c.NameSk});

            return new CategoriesListViewModel(categoriesViewModels);
        }
    }
}
