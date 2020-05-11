using System.ComponentModel.DataAnnotations;

namespace Enginex.Web.ViewModels.Account
{
    public class UserCreateViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailConfirmed { get; set; }
    }
}
