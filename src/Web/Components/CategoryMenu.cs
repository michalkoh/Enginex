﻿using Enginex.Application.Categories.Queries;
using Enginex.Web.ViewModels.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Enginex.Web.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IMediator mediator;

        public CategoryMenu(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new CategoryListViewModel()
            {
                Categories = await this.mediator.Send(new GetCategoryListQuery()),
                SelectedCategoryId = ParseSelectedCategoryId()
            });
        }

        private int? ParseSelectedCategoryId()
        {
            return int.TryParse(RouteData.Values["categoryId"] as string, out var categoryId) ? (int?)categoryId : null;
        }
    }
}
