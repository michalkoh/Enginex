using Enginex.Domain;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Enginex.Application.FileUpload
{
    public class ImageFileUpload
    {
        public const string ImageFolder = "images/products";

        private readonly IFile file;
        private readonly string rootFolder;

        public ImageFileUpload(IFile file, string rootFolder)
        {
            this.file = file;
            this.rootFolder = rootFolder;
        }

        public async Task<string> UploadAsync()
        {
            var imageFolder = Path.Combine(this.rootFolder, ImageFolder);
            var uniqueFileName = Guid.NewGuid() + "_" + this.file.FileName;
            var filePath = Path.Combine(imageFolder, uniqueFileName);
            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await this.file.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }
    }
}
