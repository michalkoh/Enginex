using Enginex.Application.Localization;
using Enginex.Application.Mapping;
using Enginex.Domain.Entities;

namespace Enginex.Application.Products.Queries
{
    internal class ProductDtoMapper : IMapper<Product, ProductDto>
    {
        private readonly ICurrentCulture currentCulture;

        public ProductDtoMapper(ICurrentCulture currentCulture)
        {
            this.currentCulture = currentCulture;
        }

        public ProductDto Map(Product product)
        {
            return new ProductDto(
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
