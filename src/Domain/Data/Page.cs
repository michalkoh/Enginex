using System.Collections.Generic;

namespace Enginex.Domain.Data
{
    public class Page<T>
    {
        public Page(IReadOnlyList<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        public int TotalCount { get; }

        public IReadOnlyList<T> Items { get; }
    }
}
