using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace Enginex.Web.ViewModels.Account
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
