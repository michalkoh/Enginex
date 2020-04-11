using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Domain
{
    public interface IFile
    {
        string FileName { get; }

        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default);
    }
}
