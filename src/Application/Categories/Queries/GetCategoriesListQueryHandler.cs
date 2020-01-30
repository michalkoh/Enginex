using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Entities;
using MediatR;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, CategoriesListViewModel>
    {
        private readonly IRepository repository;
        private readonly IMapper<Category, CategoryViewModel> mapper;

        public GetCategoriesListQueryHandler(IRepository repository, IMapper<Category, CategoryViewModel> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoriesListViewModel> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            var categoriesViewModels = categories.Select(c => this.mapper.Map(c));

            return new CategoriesListViewModel(categoriesViewModels);
        }
    }
}
