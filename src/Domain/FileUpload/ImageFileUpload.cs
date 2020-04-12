using System;
using System.IO;
using System.Threading.Tasks;

namespace Enginex.Domain.FileUpload
{
    public class ImageFileUpload : IImageFileUpload
    {
        public const string ImageFolder = "images/products";

        public static readonly IImageFileUpload None = new NoImageUpload();

        private readonly IFile file;
        private readonly string rootFolder;

        public ImageFileUpload(IFile file, string rootFolder)
        {
            this.file = file;
            this.rootFolder = rootFolder;
            UploadPending = true;
        }

        public bool UploadPending { get; private set; }

        public async Task<string> UploadAsync()
        {
            var imageFolder = Path.Combine(this.rootFolder, ImageFolder);
            return await SaveImage(imageFolder);
        }

        public async Task<string> UploadAsync(string previousImage)
        {
            var imageFolder = Path.Combine(this.rootFolder, ImageFolder);
            DeletePreviousImage(imageFolder, previousImage);
            return await SaveImage(imageFolder);
        }

        private async Task<string> SaveImage(string imageFolder)
        {
            var uniqueFileName = Guid.NewGuid() + "_" + this.file.FileName;
            var filePath = Path.Combine(imageFolder, uniqueFileName);
            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await this.file.CopyToAsync(fileStream);
            }

            UploadPending = false;

            return uniqueFileName;
        }

        private static void DeletePreviousImage(string imageFolder, string previousImage)
        {
            var previousImageFile = Path.Combine(imageFolder, previousImage);
            if (File.Exists(previousImageFile))
            {
                File.Delete(previousImageFile);
            }
        }

        private class NoImageUpload : IImageFileUpload
        {
            public bool UploadPending { get; } = false;

            public Task<string> UploadAsync()
            {
                return Task.FromResult(string.Empty);
            }

            public Task<string> UploadAsync(string previousImage)
            {
                return Task.FromResult(string.Empty);
            }
        }
    }
}
