﻿using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private const int CategoriesMaxCount = 6;

        private readonly IRepository repository;
        private readonly IStringLocalizer<SharedResource> localizer;

        public CreateCategoryCommandHandler(IRepository repository, IStringLocalizer<SharedResource> localizer)
        {
            this.repository = repository;
            this.localizer = localizer;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetCategoriesAsync();
            if (categories.Count() == CategoriesMaxCount)
            {
                throw new BusinessException(this.localizer["MaxCategoryCountReached", CategoriesMaxCount]);
            }

            if (categories.Any(c => request.Order == c.Order))
            {
                throw new BusinessException(this.localizer["CategoryOrderMustBeUnique"]);
            }

            var category = new Category(request.Name, request.Order);
            await this.repository.AddCategoryAsync(category);

            return Unit.Value;
        }
    }
}
