﻿namespace Enginex.Domain
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
