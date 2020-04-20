using System.ComponentModel.DataAnnotations;
using Enginex.Web.Resources;

namespace Enginex.Web.ViewModels.Product
{
    public class RequestViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(ValidationResources))]
        public string? Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string? Message { get; set; }

        public string? CaptchaToken { get; set; }
    }
}
