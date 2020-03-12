using Enginex.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace Enginex.Web.ViewModels
{
    public class RequestViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(ValidationResources))]
        public string? Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string? Message { get; set; }

        public string? CaptchaToken { get; set; }
    }
}
