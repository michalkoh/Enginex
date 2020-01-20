using System.Collections.Generic;
using System.Threading.Tasks;
using Enginex.Domain.Entities;

namespace Enginex.Domain
{
    public interface IRepository
    {
        Task<IList<Category>> GetCategoriesAsync();

        Task<IPage<Product>> GetProductsAsync(IPageArgument pageArgument);
    }
}
