using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace Enginex.Web.ViewModels.Admin
{
    public class LoginViewModel
    {
        public LoginViewModel(string returnUrl, IList<AuthenticationScheme> externalLogins)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = externalLogins;
        }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
