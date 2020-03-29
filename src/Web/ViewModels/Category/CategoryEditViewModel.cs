namespace Enginex.Web.ViewModels.Category
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
    }
}
