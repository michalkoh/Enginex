﻿using Enginex.Application.Categories.Queries;
using Enginex.Application.Products.Queries;
using Enginex.Domain.Data;
using Enginex.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Enginex.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IWebHostEnvironment environment;

        public AdminController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Products(int? categoryId, int? page)
        {
            var pageArgument = new PageArgument(page ?? 1);
            var productPage = await Mediator.Send(new GetProductEditListQuery(pageArgument));
            return View(new ProductEditListViewModel(productPage, pageArgument));
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await Mediator.Send(new GetCategoryListQuery());
            return View(new ProductEditViewModel(categories));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductEditViewModel productModel)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(productModel.ToCreateCommand(this.environment.WebRootPath));
                return RedirectToAction(nameof(Products));
            }

            productModel.Categories = await Mediator.Send(new GetCategoryListQuery());
            return View(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await Mediator.Send(new GetProductEditQuery(id));
            var categories = await Mediator.Send(new GetCategoryListQuery());
            return View(new ProductEditViewModel(product, categories));
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditViewModel productEditViewModel)
        {
            var categories = await Mediator.Send(new GetCategoryListQuery());
            return View(new ProductEditViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await Mediator.Send(new GetCategoryEditListQuery());
            return View(new CategoryEditListViewModel(categories));
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View(new CategoryEditViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryEditViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(categoryModel.ToCreateCommand());
                return RedirectToAction(nameof(Categories));
            }

            return View(categoryModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await Mediator.Send(new GetCategoryEditQuery(id));
            return View(new CategoryEditViewModel(category));
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryEditViewModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(categoryModel.ToEditCommand());
                return RedirectToAction(nameof(Categories));
            }

            return View(categoryModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await Mediator.Send(new GetCategoryEditQuery(id));
            return View(new CategoryEditViewModel(category));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(CategoryEditViewModel categoryModel)
        {
            await Mediator.Send(categoryModel.ToDeleteCommand());
            return RedirectToAction(nameof(Categories));
        }
    }
}
