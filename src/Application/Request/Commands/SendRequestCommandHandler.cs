using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Enginex.Application.Request.Commands
{
    public class SendRequestCommandHandler : IRequestHandler<SendRequestCommand>
    {
        private readonly IRepository repository;
        private readonly IEmailSender emailSender;
        private readonly IStringLocalizer<SharedResource> localizer;

        public SendRequestCommandHandler(IRepository repository, IEmailSender emailSender, IStringLocalizer<SharedResource> localizer)
        {
            this.repository = repository;
            this.emailSender = emailSender;
            this.localizer = localizer;
        }

        public async Task<Unit> Handle(SendRequestCommand request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.ProductId);
            if (product is null)
            {
                throw new BusinessException(this.localizer["ProductNotFound", request.ProductId]);
            }

            await this.emailSender.SendEmailAsync(request.Email, FormatSubject(product), FormatMessage(product, request));
            return Unit.Value;
        }

        private static string FormatSubject(Product product)
        {
            return $"Požiadavka zákazníka: {product.Name.Slovak}, {product.Type}";
        }

        private static string FormatMessage(Product product, SendRequestCommand request)
        {
            return $@"
{request.Message}
<br /><br/>
Produkt: {product.Name.Slovak} {product.Type}<br/>
E-mail: <a href=""mailto:{request.Email}"">{request.Email}</a><br/>
Link: <a href=""{request.ProductUrl}"">{request.ProductUrl}</a>
<br/>

---------------------------------------------------<br/>
Toto je automaticky generovaná správa - neodpovedajte na ňu!
Pre odpoveď použite adresu: <a href=""mailto:{request.Email}"">{request.Email}</a>";
        }
    }
}
