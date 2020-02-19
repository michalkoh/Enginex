using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Enginex.Domain;

namespace Enginex.Application.Email.Commands
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand>
    {
        private readonly IEmailSender emailSender;

        public SendEmailCommandHandler(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public async Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            await this.emailSender.SendEmailAsync(request.Email, request.Subject, $"{request.Message}\n\nName: {request.Name}");
            return Unit.Value;
        }
    }
}
