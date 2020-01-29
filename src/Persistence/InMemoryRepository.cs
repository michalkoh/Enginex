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
                },
                new Category()
                {
                    NameSk = "Tvárniace stroje",
                },
                new Category()
                {
                    NameSk = "Stroje na ozubenie",
                },
                new Category()
                {
                    NameSk = "Ostatné stroje a príslušenstvo",
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
