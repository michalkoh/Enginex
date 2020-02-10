using Enginex.Application.Localization;
using Enginex.Application.Mapping;
using Enginex.Domain.Entities;

namespace Enginex.Application.Products.Queries
{
    internal class ProductViewModelMapper : IMapper<Product, ProductViewModel>
    {
        private readonly ICurrentCulture currentCulture;

        public ProductViewModelMapper(ICurrentCulture currentCulture)
        {
            this.currentCulture = currentCulture;
        }

        public ProductViewModel Map(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name.Translate(this.currentCulture),
                Type = product.Type,
                CategoryId = product.Category.Id,
                CategoryName = product.Category.Name.Translate(this.currentCulture),
                Description = product.Description?.Translate(this.currentCulture),
                ImagePath = product.ImagePath
            };
        }
    }
}
