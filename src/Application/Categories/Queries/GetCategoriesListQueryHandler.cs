using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Enginex.Domain;

namespace Enginex.Application.Categories.Queries
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
            //var categories = await this.repository.GetCategoriesAsync().ProjectTo<CategoryViewModel>
            throw new NotImplementedException();
        }
    }
}
