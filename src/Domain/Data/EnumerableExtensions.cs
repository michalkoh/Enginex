using System.Collections.Generic;
using System.Linq;

namespace Enginex.Domain.Data
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> GetPage<T>(this IOrderedEnumerable<T> items, PageArgument pageArgument)
        {
            return items.Skip((pageArgument.Page - 1) * pageArgument.Size).Take(pageArgument.Size);
        }
    }
}
