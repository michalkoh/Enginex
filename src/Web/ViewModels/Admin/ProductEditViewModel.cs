using Enginex.Application.Products.Commands;
using Enginex.Application.Products.Queries;
using Enginex.Web.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Enginex.Web.ViewModels.Admin
{
    public class ProductEditViewModel
    {
        public ProductEditViewModel()
        {
            NameSlovak = string.Empty;
            NameEnglish = string.Empty;
            Type = string.Empty;
            DescriptionSlovak = string.Empty;
            DescriptionEnglish = string.Empty;
            ImagePath = string.Empty;
            Categories = new List<Application.Categories.Queries.Category>(0);
        }

        public ProductEditViewModel(ProductEdit product, IReadOnlyList<Application.Categories.Queries.Category> categories)
            : this(categories)
        {
            Id = product.Id;
            NameSlovak = product.Name.Slovak;
            NameEnglish = product.Name.English;
            Type = product.Type;
            DescriptionSlovak = product.Description.Slovak;
            DescriptionEnglish = product.Description.English;
            ImagePath = product.ImagePath;
            SelectedCategoryId = product.CategoryId;
        }

        public ProductEditViewModel(IReadOnlyList<Application.Categories.Queries.Category> categories)
            : this()
        {
            Categories = categories;
        }

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameSlovak { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameEnglish { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Type { get; set; }

        public string DescriptionSlovak { get; set; }

        public string DescriptionEnglish { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string ImagePath { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public int? SelectedCategoryId { get; set; }

        public IReadOnlyList<Application.Categories.Queries.Category> Categories { get; set; }

        public CreateProductCommand ToCreateCommand()
        {
            return new CreateProductCommand(
                new Domain.LocalString(NameSlovak, NameEnglish),
                Type,
                ImagePath,
                new Domain.LocalString(DescriptionSlovak, DescriptionEnglish),
                SelectedCategoryId.GetValueOrDefault());
        }
    }
}
