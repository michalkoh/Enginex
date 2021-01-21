namespace Enginex.Web.ViewModels.Admin
{
    public class WebAppViewModel
    {
        public WebAppViewModel()
        {
            TargetFramework = string.Empty;
            AssemblyInformationalVersion = string.Empty;
        }

        public string TargetFramework { get; set; }

        public string AssemblyInformationalVersion { get; set; }
    }
}
