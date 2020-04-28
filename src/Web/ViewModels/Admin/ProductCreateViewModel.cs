using Enginex.Application.Products.Commands;
using Enginex.Web.Resources;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Enginex.Web.ViewModels.Admin
{
    public class ProductCreateViewModel
    {
        public ProductCreateViewModel()
        {
            NameSlovak = string.Empty;
            NameEnglish = string.Empty;
            Type = string.Empty;
            Image = null!;
            Categories = new List<Application.Categories.Queries.Category>(0);
        }

        public ProductCreateViewModel(IReadOnlyList<Application.Categories.Queries.Category> categories)
            : this()
        {
            Categories = categories;
        }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameSlovak { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameEnglish { get; set; }

        public string? Type { get; set; }

        public string? DescriptionSlovak { get; set; }

        public string? DescriptionEnglish { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public IFormFile Image { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public int? SelectedCategoryId { get; set; }

        public IReadOnlyList<Application.Categories.Queries.Category> Categories { get; set; }

        public CreateProductCommand ToCommand()
        {
            return new CreateProductCommand(
                new Domain.LocalString(NameSlovak, NameEnglish),
                Type ?? string.Empty,
                new Infrastructure.FileUpload.FormFile(Image),
                new Domain.LocalString(DescriptionSlovak ?? string.Empty, DescriptionEnglish ?? string.Empty),
                SelectedCategoryId.GetValueOrDefault());
        }
    }
}
