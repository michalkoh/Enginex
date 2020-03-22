using Enginex.Application.Mapping;

namespace Enginex.Application.Products.Queries
{
    internal class ProductEditMapper : IMapper<Domain.Entities.Product, ProductEdit>
    {
        public ProductEdit Map(Domain.Entities.Product product)
        {
            return new ProductEdit(
                product.Id,
                product.Name,
                product.Type,
                product.Description,
                product.ImagePath,
                product.Category.Id);
        }
    }
}
