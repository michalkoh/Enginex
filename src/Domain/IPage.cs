using System.Collections.Generic;

namespace Enginex.Domain
{
    public interface IPage<TEntity>
    {
        IList<TEntity> Items { get; }

        IPageArgument PageArgument { get; }
    }
}
