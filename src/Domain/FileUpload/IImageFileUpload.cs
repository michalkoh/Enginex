using System.Threading.Tasks;

namespace Enginex.Domain.FileUpload
{
    public interface IImageFileUpload
    {
        bool UploadPending { get; }

        Task<string> UploadAsync();

        Task<string> UploadAsync(string previousImage);
    }
}