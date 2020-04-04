using System.ComponentModel.DataAnnotations;
using Enginex.Application.Categories.Commands;
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

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameSlovak { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string NameEnglish { get; set; }

        public CreateCategoryCommand ToCreateCommand()
        {
            return new CreateCategoryCommand(new LocalString(NameSlovak, NameEnglish));
        }

        public EditCategoryCommand ToEditCommand()
        {
            return new EditCategoryCommand(Id, new LocalString(NameSlovak, NameEnglish));
        }

        public DeleteCategoryCommand ToDeleteCommand()
        {
            return new DeleteCategoryCommand(Id);
        }
    }
}
