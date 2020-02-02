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

        public Task<IPage<Product>> GetProductsAsync(IPageArgument pageArgument)
        {
            throw new System.NotImplementedException();
        }
    }
}
