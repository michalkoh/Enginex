using MediatR;

namespace Enginex.Application.Email.Commands
{
    public class SendEmailCommand : IRequest
    {
        public string Email { get; set; }
        
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
