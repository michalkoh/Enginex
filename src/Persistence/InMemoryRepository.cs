using Enginex.Domain;
using Enginex.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enginex.Persistence
{
    public class InMemoryRepository : IRepository
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = new List<Category>()
            {
                new Category(1, "Kovoobrábacie stroje", "Metalworking machines"),
                new Category(2, "Tvárniace stroje", "Forming machines"),
                new Category(3, "Stroje na ozubenie", "Gear machinery"),
                new Category(4, "Ostatné stroje a príslušenstvo", "Other machinery and accessories")
            };

            return Task.FromResult(categories.AsEnumerable());
        }

        public Task<IEnumerable<Product>> GetProductsAsync(ISpecification<Product> specification)
        {
            var products = new List<Product>()
            {
                new Product(1, 1, "Frezka vertikalna", "Vertical milling machine", "FA 4 V"),
                new Product(2, 1, "Bruska na otvory", "Hole grinder", "Si 125x175"),
                new Product(3, 1, "Bruska na zavity", "Thread grinder", "5822 M"),
                new Product(4, 1, "Bruska rovinna", "Surface grinding machine", "BLOHM HFS 9"),
                new Product(5, 2, "Tabulove noznice", "Table shears", "CNTA 3150/10"),
                new Product(6, 2, "Ohybacka plechu", "Sheet bender", "CIDAN K 25-20"),
            };

            return Task.FromResult(products.Where(specification.IsSatisfiedBy).AsEnumerable());
        }
    }
}
