using System.Threading.Tasks;

namespace Enginex.Domain.FileService
{
    public interface IFileUpload
    {
        Task<string> UploadImageAsync(IFile file);

        void DeleteImage(string filename);
    }
}
