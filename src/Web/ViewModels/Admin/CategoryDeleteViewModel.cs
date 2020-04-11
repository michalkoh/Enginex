using Enginex.Application.Categories.Commands;
using Enginex.Application.Categories.Queries;

namespace Enginex.Web.ViewModels.Admin
{
    public class CategoryDeleteViewModel
    {
        public CategoryDeleteViewModel(CategoryEdit category)
        {
            Id = category.Id;
            Name = category.Name.Slovak;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DeleteCategoryCommand ToCommand()
        {
            return new DeleteCategoryCommand(Id);
        }
    }
}
