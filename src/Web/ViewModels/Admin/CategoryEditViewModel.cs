using Enginex.Application.Categories.Commands;
using Enginex.Domain;

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

        public string NameSlovak { get; set; }

        public string NameEnglish { get; set; }

        public CreateCategoryCommand ToCreateCommand()
        {
            return new CreateCategoryCommand(new LocalString(NameSlovak, NameEnglish));
        }

        public EditCategoryCommand ToEditCommand()
        {
            return new EditCategoryCommand(Id, new LocalString(NameSlovak, NameEnglish));
        }
    }
}
