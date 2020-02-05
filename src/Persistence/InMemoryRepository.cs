using Enginex.Domain;
using Enginex.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enginex.Persistence
{
    public class InMemoryRepository : IRepository
    {
        private readonly IList<Product> products;
        private readonly IList<Category> categories;

        public InMemoryRepository()
        { 
            this.categories = new List<Category>()
            {
                new Category(1, "Kovoobrábacie stroje", "Metalworking machines"),
                new Category(2, "Tvárniace stroje", "Forming machines"),
                new Category(3, "Stroje na ozubenie", "Gear machinery"),
                new Category(4, "Ostatné stroje a príslušenstvo", "Other machinery and accessories")
            };

            this.products = new List<Product>()
            {
                new Product(1, 1, "Frezka vertikalna", "Vertical milling machine", "FA 4 V", "~/images/products/02.jpg"),
                new Product(2, 1, "Bruska na otvory", "Hole grinder", "Si 125x175", "~/images/products/03.jpg"),
                new Product(3, 1, "Bruska na zavity", "Thread grinder", "5822 M", "~/images/products/04.jpg"),
                new Product(4, 1, "Bruska rovinna", "Surface grinding machine", "BLOHM HFS 9", "~/images/products/05.jpg"),
                new Product(5, 2, "Tabulove noznice", "Table shears", "CNTA 3150/10", "~/images/products/06.jpg"),
                new Product(6, 2, "Ohybacka plechu", "Sheet bender", "CIDAN K 25-20", "~/images/products/07.jpg"),
            };
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
