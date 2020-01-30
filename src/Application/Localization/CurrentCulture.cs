namespace Enginex.Application.Localization
{
    internal class CurrentCulture : ICurrentCulture
    {
        public CurrentCulture()
        {
            Culture = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "sk" ? Culture.Slovak : Culture.English;
        }

        public Culture Culture { get; }
    }
}
