using Enginex.Domain.Data;
using Enginex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enginex.Infrastructure.Persistence
{
    public class Repository : IRepository
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await this.context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await this.context.Categories.ToListAsync();
        }

        public async Task AddCategoryAsync(Category category)
        {
            // TODO Gruad argument
            this.context.Categories.Add(category);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            this.context.Categories.Update(category);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            this.context.Categories.Remove(category);
            await this.context.SaveChangesAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await this.context.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(ISpecification<Product> specification)
        {
            return await this.context.Products.Where(specification.ToExpression()).ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            // TODO Gruad argument
            this.context.Products.Add(product);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            this.context.Products.Update(product);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            this.context.Products.Remove(product);
            await this.context.SaveChangesAsync();
        }
    }
}
