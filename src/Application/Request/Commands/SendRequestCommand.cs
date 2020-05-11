using MediatR;

namespace Enginex.Application.Request.Commands
{
    public class SendRequestCommand : IRequest
    {
        public SendRequestCommand()
        {
            From = string.Empty;
            To = string.Empty;
            Message = string.Empty;
            ProductUrl = string.Empty;
        }

        public string From { get; set; }

        public string To { get; set; }

        public string Message { get; set; }

        public int ProductId { get; set; }

        public string ProductUrl { get; set; }
    }
}
