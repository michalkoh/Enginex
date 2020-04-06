using System.Collections.Generic;
using System.Threading.Tasks;
using Enginex.Domain.Entities;

namespace Enginex.Domain.Data
{
    public interface IRepository
    {
        Task<Category> GetCategoryAsync(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task AddCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);

        Task DeleteCategoryAsync(Category category);

        Task<Product> GetProductAsync(int id);

        Task<IEnumerable<Product>> GetProductsAsync(ISpecification<Product> specification);

        Task AddProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(Product product);
    }
}
