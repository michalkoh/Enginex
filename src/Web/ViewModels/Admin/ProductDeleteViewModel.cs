﻿using Enginex.Application.Products.Commands;
using Enginex.Application.Products.Queries;

namespace Enginex.Web.ViewModels.Admin
{
    public class ProductDeleteViewModel
    {
        public ProductDeleteViewModel()
        {
            Name = string.Empty;
        }

        public ProductDeleteViewModel(ProductEdit product)
            : this()
        {
            Id = product.Id;
            Name = product.Name.Slovak;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DeleteProductCommand ToCommand()
        {
            return new DeleteProductCommand(Id);
        }
    }
}
