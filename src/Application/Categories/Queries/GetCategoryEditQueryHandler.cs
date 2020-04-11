using Enginex.Application.Mapping;
using Enginex.Domain;
using Enginex.Domain.Data;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoryEditQueryHandler : IRequestHandler<GetCategoryEditQuery, CategoryEdit>
    {
        private readonly IRepository repository;
        private readonly IMapper<Domain.Entities.Category, CategoryEdit> mapper;
        private readonly IStringLocalizer<SharedResource> localizer;

        public GetCategoryEditQueryHandler(IRepository repository, IMapper<Domain.Entities.Category, CategoryEdit> mapper, IStringLocalizer<SharedResource> localizer)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.localizer = localizer;
        }

        public async Task<CategoryEdit> Handle(GetCategoryEditQuery request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetCategoryAsync(request.CategoryId);
            if (category is null)
            {
                throw new BusinessException(this.localizer["CategoryNotFound", request.CategoryId]);
            }

            return this.mapper.Map(category);
        }
    }
}
