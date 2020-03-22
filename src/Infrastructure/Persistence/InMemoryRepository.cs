using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Domain.Entities;

namespace Enginex.Infrastructure.Persistence
{
    public class InMemoryRepository : IRepository
    {
        private readonly IList<Product> products;
        private readonly IList<Category> categories;

        public InMemoryRepository()
        {
            var category1 = new Category(1, new LocalString("Kovoobrábacie stroje", "Metalworking machines"));
            var category2 = new Category(2, new LocalString("Tvárniace stroje", "Forming machines"));
            var category3 = new Category(3, new LocalString("Stroje na ozubenie", "Gear machinery"));
            var category4 = new Category(4, new LocalString("Ostatné stroje a príslušenstvo", "Other machinery and accessories"));
            this.categories = new List<Category>() { category1, category2, category3, category4 };

            this.products = new List<Product>()
            {
                new Product(1, new LocalString("Frezka vertikalna", "Vertical milling machine"), "FA 4 V", "~/images/products/02.jpg", category1),
                new Product(2, new LocalString("Bruska na otvory", "Hole grinder"), "Si 125x175", "~/images/products/03.jpg", category1),
                new Product(3, new LocalString("Bruska na zavity", "Thread grinder"), "5822 M", "~/images/products/04.jpg", category1),
                new Product(4, new LocalString("Bruska rovinna", "Surface grinding machine"), "BLOHM HFS 9", "~/images/products/05.jpg", category1),
                new Product(5, new LocalString("Tabulove noznice", "Table shears"), "CNTA 3150/10", "~/images/products/06.jpg", category2),
                new Product(6, new LocalString("Ohybacka plechu", "Sheet bender"), "CIDAN K 25-20", "~/images/products/07.jpg", category2),
            };
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return Task.FromResult(this.categories.SingleOrDefault(c => c.Id == id));
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return Task.FromResult(this.categories.AsEnumerable());
        }

        public Task<Product> GetProductAsync(int id)
        {
            return Task.FromResult(this.products.SingleOrDefault(p => p.Id == id));
        }

        public Task<IEnumerable<Product>> GetProductsAsync(ISpecification<Product> specification)
        {
            return Task.FromResult(this.products.Where(specification.IsSatisfiedBy).AsEnumerable());
        }
    }
}
