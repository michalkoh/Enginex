using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoryEditQueryHandler : IRequestHandler<GetCategoryEditQuery, CategoryEdit>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Category, CategoryEdit> mapper;

        public GetCategoryEditQueryHandler(IRepository repository, IMapper<Domain.Entities.Category, CategoryEdit> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryEdit> Handle(GetCategoryEditQuery request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetCategoryAsync(request.CategoryId);

            if (category is null)
            {
                throw new BusinessException("Kategória neexistuje.");
            }

            return this.mapper.Map(category);
        }
    }
}
