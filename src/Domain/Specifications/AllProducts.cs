using Enginex.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Enginex.Domain.Specifications
{
    public class AllProducts : SpecificationBase<Product>
    {
        public override Expression<Func<Product, bool>> ToExpression()
        {
            return p => true;
        }
    }
}
