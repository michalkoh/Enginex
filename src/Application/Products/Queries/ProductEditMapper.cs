using Dawn;
using Enginex.Application.Mapping;

namespace Enginex.Application.Products.Queries
{
    internal class ProductEditMapper : IMapper<Domain.Entities.Product, ProductEdit>
    {
        public ProductEdit Map(Domain.Entities.Product product)
        {
            Guard.Argument(product, nameof(product)).NotNull();

            return new ProductEdit(
                product.Id,
                product.Name,
                product.Type,
                product.Description,
                product.Image,
                product.Category.Id);
        }
    }
}
