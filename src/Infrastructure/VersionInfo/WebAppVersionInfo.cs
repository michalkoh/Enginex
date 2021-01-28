using Dawn;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace Enginex.Infrastructure.VersionInfo
{
    public class WebAppVersionInfo
    {
        private WebAppVersionInfo()
        {
            TargetFramework = string.Empty;
            AssemblyVersion = string.Empty;
        }

        public string TargetFramework { get; private set; }

        public string AssemblyVersion { get; private set; }

        public static WebAppVersionInfo Load(Assembly assembly)
        {
            Guard.Argument(assembly, nameof(assembly)).NotNull();

            return new WebAppVersionInfo()
            {
                TargetFramework = GetTargetFramework(assembly),
                AssemblyVersion = GetAssemblyVersion(assembly)
            };
        }

        private static string GetTargetFramework(ICustomAttributeProvider assembly)
        {
            var targetFrameworkAttribute = assembly
                .GetCustomAttributes(typeof(TargetFrameworkAttribute), false)
                .SingleOrDefault() as TargetFrameworkAttribute;

            return targetFrameworkAttribute?.FrameworkName ?? string.Empty;
        }

        private static string GetAssemblyVersion(Assembly assembly)
        {
            return assembly.GetName().Version.ToString();
        }
    }
}
