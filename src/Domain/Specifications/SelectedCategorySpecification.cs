using System;
using System.Linq.Expressions;
using Enginex.Domain.Entities;

namespace Enginex.Domain.Specifications
{
    public class SelectedCategorySpecification : SpecificationBase<Product>
    {
        private readonly int? categoryId;

        public SelectedCategorySpecification(int? categoryId)
        {
            this.categoryId = categoryId;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            if (this.categoryId.HasValue)
            {
                return p => p.CategoryId == this.categoryId;
            }

            return p => true;
        }
    }
}
