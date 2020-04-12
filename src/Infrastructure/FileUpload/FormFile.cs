using Enginex.Domain.FileUpload;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Infrastructure.FileUpload
{
    public class FormFile : IFile
    {
        private readonly IFormFile formFile;

        public FormFile(IFormFile formFile)
        {
            this.formFile = formFile;
        }

        public string FileName => this.formFile.FileName;

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return this.formFile.CopyToAsync(target, cancellationToken);
        }
    }
}
