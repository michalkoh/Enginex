using System;
using System.Linq.Expressions;

namespace Enginex.Domain.Data
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> ToExpression();

        bool IsSatisfiedBy(T entity);
    }
}
