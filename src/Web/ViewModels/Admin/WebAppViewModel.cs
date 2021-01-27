namespace Enginex.Web.ViewModels.Admin
{
    public class WebAppViewModel
    {
        public WebAppViewModel()
        {
            TargetFramework = string.Empty;
            AssemblyVersion = string.Empty;
        }

        public string TargetFramework { get; set; }

        public string AssemblyVersion { get; set; }
    }
}
