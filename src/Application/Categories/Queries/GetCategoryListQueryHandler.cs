using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IReadOnlyList<CategoryDto>>
    {
        private readonly IRepository repository;
        private readonly IMapper<Category, CategoryDto> mapper;

        public GetCategoryListQueryHandler(IRepository repository, IMapper<Category, CategoryDto> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            return categories.Select(c => this.mapper.Map(c)).ToList().AsReadOnly();
        }
    }
}
