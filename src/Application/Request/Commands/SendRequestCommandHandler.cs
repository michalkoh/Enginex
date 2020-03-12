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

            await this.emailSender.SendEmailAsync(request.Email, GetSubject(product), $"{request.Message} {request.Email}");
            return Unit.Value;
        }

        private static string GetSubject(Product product)
        {
            return $"Požiadavka: {product.Name.Slovak} {product.Type}";
        }
    }
}
