using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Enginex.Application.Email.Commands
{
    public class SendEmailCommand : IRequest
    {
        public SendEmailCommand()
        {
            Email = string.Empty;
            Name = string.Empty;
            Subject = string.Empty;
            Message = string.Empty;
        }

        [Required]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
