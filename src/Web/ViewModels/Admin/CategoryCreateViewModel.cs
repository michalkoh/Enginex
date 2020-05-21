using Enginex.Application.Categories.Commands;
using Enginex.Domain;
using Enginex.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace Enginex.Web.ViewModels.Admin
{
    public class CategoryCreateViewModel
    {
        public CategoryCreateViewModel()
        {
            NameSlovak = string.Empty;
            NameEnglish = string.Empty;
        }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameSlovak { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameEnglish { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        [Range(1, 999, ErrorMessageResourceName = "PositiveNumbersOnly", ErrorMessageResourceType = typeof(ValidationResources))]
        public ushort Order { get; set; }

        public CreateCategoryCommand ToCommand()
        {
            return new CreateCategoryCommand(new LocalString(NameSlovak, NameEnglish), Order);
        }
    }
}
