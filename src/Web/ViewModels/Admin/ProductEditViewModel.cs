using Enginex.Application.Products.Commands;
using Enginex.Application.Products.Queries;
using Enginex.Web.Resources;
using Microsoft.AspNetCore.Http;
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
            Image = null!;
            Categories = new List<Application.Categories.Queries.Category>(0);
        }

        public ProductEditViewModel(ProductEdit product, IReadOnlyList<Application.Categories.Queries.Category> categories)
            : this()
        {
            Id = product.Id;
            NameSlovak = product.Name.Slovak;
            NameEnglish = product.Name.English;
            Type = product.Type;
            DescriptionSlovak = product.Description.Slovak;
            DescriptionEnglish = product.Description.English;
            Image = null!;
            SelectedCategoryId = product.CategoryId;
            Categories = categories;
        }

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameSlovak { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameEnglish { get; set; }

        public string? Type { get; set; }

        public string? DescriptionSlovak { get; set; }

        public string? DescriptionEnglish { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public int? SelectedCategoryId { get; set; }

        public IReadOnlyList<Application.Categories.Queries.Category> Categories { get; set; }

        public EditProductCommand ToCommand()
        {
            return new EditProductCommand(
                Id,
                new Domain.LocalString(NameSlovak, NameEnglish),
                Type ?? string.Empty,
                Image is null ? null : new Infrastructure.FileUpload.FormFile(Image),
                new Domain.LocalString(DescriptionSlovak ?? string.Empty, DescriptionEnglish ?? string.Empty),
                SelectedCategoryId.GetValueOrDefault());
        }
    }
}
