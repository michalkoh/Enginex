using Enginex.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enginex.Infrastructure.Persistence
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Products = null!;
            Categories = null!;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
