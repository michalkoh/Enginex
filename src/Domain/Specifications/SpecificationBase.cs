using System;
using System.Linq.Expressions;

namespace Enginex.Domain.Specifications
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}
