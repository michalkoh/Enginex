using Enginex.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
            await this.emailSender.SendEmailAsync(request.Email, request.Subject, $"{request.Message}{request.Name} {request.Email}");
            return Unit.Value;
        }
    }
}
