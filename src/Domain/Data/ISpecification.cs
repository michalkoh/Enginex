namespace Enginex.Domain.Data
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
