using System.Collections.Generic;
using System.Threading.Tasks;
using Enginex.Domain.Entities;

namespace Enginex.Domain.Data
{
    public interface IRepository
    {
        Task<Category> GetCategoryAsync(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Product> GetProductAsync(int id);

        Task<IEnumerable<Product>> GetProductsAsync(ISpecification<Product> specification);
    }
}
