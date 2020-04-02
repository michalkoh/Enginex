using Enginex.Domain.Data;
using Enginex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enginex.Infrastructure.Persistence
{
    internal class Repository : IRepository
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

        public async Task<Product> GetProductAsync(int id)
        {
            return await this.context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(ISpecification<Product> specification)
        {
            return await this.context.Products.Where(specification.ToExpression()).ToListAsync();
        }
    }
}
