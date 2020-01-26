using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Enginex.Domain;
using Enginex.Domain.Entities;
using MediatR;

namespace Enginex.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, CategoriesListViewModel>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public GetCategoriesListQueryHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoriesListViewModel> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            var categoriesViewModels = this.mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return new CategoriesListViewModel(categoriesViewModels);
        }
    }
}
