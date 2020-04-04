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
            await this.emailSender.SendEmailAsync(request.Email, request.Subject, FormatMessage(request));
            return Unit.Value;
        }

        private static string FormatMessage(SendEmailCommand request)
        {
            return $@"
{request.Message}
<br /><br/>
Meno: {request.Name}<br/>
Mail: <a href=""mailto:{request.Email}"">{request.Email}</a><br/>
<br/>

---------------------------------------------------<br/>
DÔLEŽITÉ: Na túto správu neodpovedajte priamo, ale použite mail: <a href=""mailto:{request.Email}"">{request.Email}</a>";
        }
    }
}
