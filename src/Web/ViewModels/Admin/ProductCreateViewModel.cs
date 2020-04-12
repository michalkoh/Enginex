using Enginex.Application.Products.Commands;
using Enginex.Domain.FileUpload;
using Enginex.Web.Resources;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Enginex.Web.ViewModels.Admin
{
    public class ProductCreateViewModel
    {
        public ProductCreateViewModel(IReadOnlyList<Application.Categories.Queries.Category> categories)
        {
            NameSlovak = string.Empty;
            NameEnglish = string.Empty;
            Type = string.Empty;
            Image = null!;
            Categories = categories;
        }

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

        public CreateProductCommand ToCommand(string imageRootFolder)
        {
            return new CreateProductCommand(
                new Domain.LocalString(NameSlovak, NameEnglish),
                Type,
                new ImageFileUpload(new Infrastructure.FileUpload.FormFile(Image), imageRootFolder),
                new Domain.LocalString(DescriptionSlovak ?? string.Empty, DescriptionEnglish ?? string.Empty),
                SelectedCategoryId.GetValueOrDefault());
        }
    }
}
