using Enginex.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enginex.Domain
{
    public interface IRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<IEnumerable<Product>> GetProductsAsync(ISpecification<Product> specification);
    }
}
