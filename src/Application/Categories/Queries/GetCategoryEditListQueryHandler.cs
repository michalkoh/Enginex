using Enginex.Application.Mapping;
using Enginex.Domain.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoryEditListQueryHandler : IRequestHandler<GetCategoryEditListQuery, IReadOnlyList<CategoryEdit>>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Category, CategoryEdit> mapper;

        public GetCategoryEditListQueryHandler(IRepository repository, IMapper<Domain.Entities.Category, CategoryEdit> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<CategoryEdit>> Handle(GetCategoryEditListQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            return categories.Select(this.mapper.Map).ToList().AsReadOnly();
        }
    }
}
