using System.Collections.Generic;
using System.Threading.Tasks;
using Enginex.Domain.Entities;

namespace Enginex.Domain.Data
{
    public interface IRepository
    {
        Task AddCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);

        Task DeleteCategoryAsync(Category category);

        Task<Category> GetCategoryAsync(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Product> GetProductAsync(int id);

        Task<IEnumerable<Product>> GetProductsAsync(ISpecification<Product> specification);
    }
}
