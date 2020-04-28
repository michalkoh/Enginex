using System;
using System.IO;
using System.Threading.Tasks;

namespace Enginex.Domain.FileService
{
    public class FileUpload : IFileUpload
    {
        public const string ImageFolder = "images/products";

        private readonly string imageFolder;

        public FileUpload(string rootFolder)
        {
            this.imageFolder = Path.Combine(rootFolder, ImageFolder);
        }

        public async Task<string> UploadImageAsync(IFile file)
        {
            return await SaveImageAsync(file, this.imageFolder);
        }

        public void DeleteImage(string filename)
        {
            var previousImageFile = Path.Combine(this.imageFolder, filename);
            if (File.Exists(previousImageFile))
            {
                File.Delete(previousImageFile);
            }
        }

        private static async Task<string> SaveImageAsync(IFile file, string imageFolder)
        {
            var uniqueFileName = Guid.NewGuid() + "_" + file.FileName;
            var filePath = Path.Combine(imageFolder, uniqueFileName);
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return uniqueFileName;
        }
    }
}
