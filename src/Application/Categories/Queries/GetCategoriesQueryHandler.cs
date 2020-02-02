using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, CategoriesViewModel>
    {
        private readonly IRepository repository;
        private readonly IMapper<Category, CategoryViewModel> mapper;

        public GetCategoriesQueryHandler(IRepository repository, IMapper<Category, CategoryViewModel> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoriesViewModel> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            var categoriesViewModels = categories.Select(c => this.mapper.Map(c));
            CategoryViewModel? selectedCategoryViewModel = null;
            if (request.SelectedCategoryId.HasValue)
            {
                var selectedCategory = categories.SingleOrDefault(c => c.Id == request.SelectedCategoryId.Value);
                selectedCategoryViewModel = this.mapper.Map(selectedCategory);
            }

            return new CategoriesViewModel(categoriesViewModels, selectedCategoryViewModel);
        }
    }
}
