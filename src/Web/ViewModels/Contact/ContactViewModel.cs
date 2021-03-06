﻿using System.ComponentModel.DataAnnotations;
using Enginex.Application.Email.Commands;
using Enginex.Web.Resources;

namespace Enginex.Web.ViewModels.Contact
{
    public class ContactViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(ValidationResources))]
        public string? Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string? Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string? Subject { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationResources))]
        public string? Message { get; set; }

        public string? CaptchaToken { get; set; }

        public SendEmailCommand ToCommand(string to)
        {
            return new SendEmailCommand()
            {
                From = Email ?? string.Empty,
                To = to,
                Name = Name ?? string.Empty,
                Subject = Subject ?? string.Empty,
                Message = Message ?? string.Empty
            };
        }
    }
}
