using Enginex.Application.Products.Commands;
using Enginex.Application.Products.Queries;
using Enginex.Web.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Enginex.Web.ViewModels.Admin
{
    public class ProductEditViewModel
    {
        public ProductEditViewModel()
        {
            NameSlovak = string.Empty;
            NameEnglish = string.Empty;
            Type = string.Empty;
            Image = null!;
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
            Image = null!;
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

        public string? DescriptionSlovak { get; set; }

        public string? DescriptionEnglish { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public IFormFile Image { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public int? SelectedCategoryId { get; set; }

        public IReadOnlyList<Application.Categories.Queries.Category> Categories { get; set; }

        public CreateProductCommand ToCreateCommand()
        {
            return new CreateProductCommand(
                new Domain.LocalString(NameSlovak, NameEnglish),
                Type,
                Image.FileName,
                new Domain.LocalString(DescriptionSlovak ?? string.Empty, DescriptionEnglish ?? string.Empty),
                SelectedCategoryId.GetValueOrDefault());
        }
    }
}
