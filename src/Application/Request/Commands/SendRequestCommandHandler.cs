using Enginex.Domain;
using Enginex.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Request.Commands
{
    public class SendRequestCommandHandler : IRequestHandler<SendRequestCommand>
    {
        private readonly IRepository repository;
        private readonly IEmailSender emailSender;

        public SendRequestCommandHandler(IRepository repository, IEmailSender emailSender)
        {
            this.repository = repository;
            this.emailSender = emailSender;
        }

        public async Task<Unit> Handle(SendRequestCommand request, CancellationToken cancellationToken)
        {
            var product = await this.repository.GetProductAsync(request.ProductId);
            if (product is null)
            {
                throw new BusinessException($"Product not found (Id: {request.ProductId}).");
            }

            await this.emailSender.SendEmailAsync(request.Email, FormatSubject(product), FormatMessage(product, request));
            return Unit.Value;
        }

        private static string FormatSubject(Product product)
        {
            return $"Požiadavka zakaznika: {product.Name.Slovak}, {product.Type}";
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
Toto je automaticky generovaná správa - neodpovedajte na ňu!";
        }
    }
}
