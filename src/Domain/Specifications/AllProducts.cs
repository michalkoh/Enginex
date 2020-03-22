using Enginex.Domain.Data;
using Enginex.Domain.Entities;

namespace Enginex.Domain.Specifications
{
    public class AllProducts : ISpecification<Product>
    {
        public bool IsSatisfiedBy(Product entity)
        {
            return true;
        }
    }
}
