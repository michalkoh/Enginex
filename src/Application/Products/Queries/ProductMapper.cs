using Enginex.Application.Localization;
using Enginex.Application.Mapping;

namespace Enginex.Application.Products.Queries
{
    internal class ProductMapper : IMapper<Domain.Entities.Product, Product>
    {
        private readonly ICurrentCulture currentCulture;

        public ProductMapper(ICurrentCulture currentCulture)
        {
            this.currentCulture = currentCulture;
        }

        public Product Map(Domain.Entities.Product product)
        {
            return new Product(
                product.Id,
                product.Name.Translate(this.currentCulture),
                product.Type,
                product.Description?.Translate(this.currentCulture),
                product.ImagePath,
                product.Category.Id,
                product.Category.Name.Translate(this.currentCulture));
        }
    }
}
