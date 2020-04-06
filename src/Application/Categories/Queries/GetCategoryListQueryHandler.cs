using Enginex.Application.Mapping;
using Enginex.Domain.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IReadOnlyList<Category>>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Category, Category> mapper;

        public GetCategoryListQueryHandler(IRepository repository, IMapper<Domain.Entities.Category, Category> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<Category>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            return categories.Select(c => this.mapper.Map(c)).OrderBy(c => c.Name).ToList().AsReadOnly();
        }
    }
}
