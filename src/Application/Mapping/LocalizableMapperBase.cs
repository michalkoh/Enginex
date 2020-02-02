using System;
using Enginex.Application.Localization;

namespace Enginex.Application.Mapping
{
    internal abstract class LocalizableMapperBase<TSource>
    {
        private readonly ICurrentCulture currentCulture;

        protected LocalizableMapperBase(ICurrentCulture currentCulture)
        {
            this.currentCulture = currentCulture;
        }

        protected T MapWithTranslation<T>(TSource source, Func<TSource, T> getSk, Func<TSource, T> getEn)
        {
            return this.currentCulture.Culture == Culture.Slovak ? getSk(source) : getEn(source);
        }
    }
}
