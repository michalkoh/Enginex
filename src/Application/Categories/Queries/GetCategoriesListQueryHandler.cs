using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, CategoriesListDto>
    {
        private readonly IRepository repository;
        private readonly IMapper<Category, CategoryDto> mapper;

        public GetCategoriesListQueryHandler(IRepository repository, IMapper<Category, CategoryDto> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoriesListDto> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            var categoriesViewModels = categories.Select(c => this.mapper.Map(c));
            CategoryDto? selectedCategoryViewModel = null;
            if (request.SelectedCategoryId.HasValue)
            {
                var selectedCategory = categories.SingleOrDefault(c => c.Id == request.SelectedCategoryId.Value);
                selectedCategoryViewModel = this.mapper.Map(selectedCategory);
            }

            return new CategoriesListDto(categoriesViewModels, selectedCategoryViewModel);
        }
    }
}
