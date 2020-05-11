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
            await this.emailSender.SendEmailAsync(request.From, request.To, request.Subject, FormatMessage(request));
            return Unit.Value;
        }

        private static string FormatMessage(SendEmailCommand request)
        {
            return $@"
{request.Message}
<br /><br/>
Meno: {request.Name}<br/>
Mail: <a href=""mailto:{request.From}"">{request.From}</a><br/>
<br/>

---------------------------------------------------<br/>
Toto je automaticky generovaná správa - neodpovedajte na ňu!
Pre odpoveď použite adresu: <a href=""mailto:{request.From}"">{request.From}</a>";
        }
    }
}
