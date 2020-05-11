using MediatR;

namespace Enginex.Application.Email.Commands
{
    public class SendEmailCommand : IRequest
    {
        public SendEmailCommand()
        {
            From = string.Empty;
            To = string.Empty;
            Name = string.Empty;
            Subject = string.Empty;
            Message = string.Empty;
        }

        public string From { get; set; }

        public string To { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
