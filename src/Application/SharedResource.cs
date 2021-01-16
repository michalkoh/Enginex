using Microsoft.Extensions.Localization;

namespace Enginex.Application
{
    public class SharedResource
    {
        private readonly IStringLocalizer localizer;

        public SharedResource(IStringLocalizer<SharedResource> localizer)
        {
            this.localizer = localizer;
        }

        public string? this[string index] => this.localizer[index];
    }
}
