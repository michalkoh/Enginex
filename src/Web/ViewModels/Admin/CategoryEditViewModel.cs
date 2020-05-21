using System.ComponentModel.DataAnnotations;
using Enginex.Application.Categories.Commands;
using Enginex.Application.Categories.Queries;
using Enginex.Domain;
using Enginex.Web.Resources;

namespace Enginex.Web.ViewModels.Admin
{
    public class CategoryEditViewModel
    {
        public CategoryEditViewModel()
        {
            NameSlovak = string.Empty;
            NameEnglish = string.Empty;
        }

        public CategoryEditViewModel(CategoryEdit category)
            : this()
        {
            Id = category.Id;
            NameSlovak = category.Name.Slovak;
            NameEnglish = category.Name.English;
            Order = category.Order;
        }

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameSlovak { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameEnglish { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        [Range(1, 999, ErrorMessageResourceName = "PositiveNumbersOnly", ErrorMessageResourceType = typeof(ValidationResources))]
        public ushort Order { get; set; }

        public EditCategoryCommand ToCommand()
        {
            return new EditCategoryCommand(Id, new LocalString(NameSlovak, NameEnglish), Order);
        }
    }
}
