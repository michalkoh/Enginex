﻿using System;
using System.Linq.Expressions;
using Enginex.Domain.Entities;

namespace Enginex.Domain.Specifications
{
    public class ProductsInCategory : SpecificationBase<Product>
    {
        private readonly int? categoryId;

        public ProductsInCategory(int? categoryId)
        {
            this.categoryId = categoryId;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            if (this.categoryId.HasValue)
            {
                return p => p.Category.Id == this.categoryId;
            }

            return p => true;
        }
    }
}