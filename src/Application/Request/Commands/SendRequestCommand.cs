﻿using MediatR;

namespace Enginex.Application.Request.Commands
{
    public class SendRequestCommand : IRequest
    {
        public SendRequestCommand()
        {
            Email = string.Empty;
            Message = string.Empty;
            ProductUrl = string.Empty;
        }

        public string Email { get; set; }

        public string Message { get; set; }

        public int ProductId { get; set; }

        public string ProductUrl { get; set; }
    }
}