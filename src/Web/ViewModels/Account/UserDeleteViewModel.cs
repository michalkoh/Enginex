using Microsoft.AspNetCore.Identity;

namespace Enginex.Web.ViewModels.Account
{
    public class UserDeleteViewModel
    {
        public UserDeleteViewModel()
        {
            Email = string.Empty;
        }

        public UserDeleteViewModel(IdentityUser user)
            : this()
        {
            Email = user.Email;
        }

        public string Email { get; set; }
    }
}
