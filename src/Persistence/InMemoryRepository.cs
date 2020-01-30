using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enginex.Domain;
using Enginex.Domain.Entities;

namespace Enginex.Persistence
{
    public class InMemoryRepository : IRepository
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    NameSk = "Kovoobrábacie stroje",
                    NameEn = "Metalworking machines"
                },
                new Category()
                {
                    NameSk = "Tvárniace stroje",
                    NameEn = "Forming machines"
                },
                new Category()
                {
                    NameSk = "Stroje na ozubenie",
                    NameEn = "Gear machinery"
                },
                new Category()
                {
                    NameSk = "Ostatné stroje a príslušenstvo",
                    NameEn = "Other machinery and accessories"
                }
            };

            return Task.FromResult(categories.AsEnumerable());
        }

        public Task<IPage<Product>> GetProductsAsync(IPageArgument pageArgument)
        {
            throw new System.NotImplementedException();
        }
    }
}
