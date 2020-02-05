using Enginex.Application.Localization;
using Enginex.Application.Mapping;
using Enginex.Domain.Entities;

namespace Enginex.Application.Products.Queries
{
    internal class ProductViewModelMapper : LocalizableMapperBase<Product>, IMapper<Product, ProductViewModel>
    {
        public ProductViewModelMapper(ICurrentCulture currentCulture) : base(currentCulture)
        {
        }

        public ProductViewModel Map(Product product)
        {
            return new ProductViewModel(
                product.Id,
                MapWithTranslation(product, p => p.NameSk, p => p.NameEn),
                product.Type,
                product.ImagePath,
                MapWithTranslation(product, p => p.DescriptionSk, p => p.DescriptionEn));
        }
    }
}
