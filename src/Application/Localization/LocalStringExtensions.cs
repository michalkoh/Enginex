using Enginex.Domain;

namespace Enginex.Application.Localization
{
    internal static class LocalStringExtensions
    {
        public static string Translate(this LocalString input, ICurrentCulture currentCulture)
        {
            if (input == null)
            {
                return string.Empty;
            }

            return currentCulture.Culture == Culture.Slovak ? input.Slovak : input.English;
        }
    }
}
