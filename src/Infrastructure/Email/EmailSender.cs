using Enginex.Domain;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Enginex.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            Contract.Requires(!string.IsNullOrEmpty(email));

            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(this.emailSettings.SenderName, this.emailSettings.Login));
                mimeMessage.From.Add(new MailboxAddress(email));
                mimeMessage.To.Add(new MailboxAddress(this.emailSettings.To));
                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message,
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(this.emailSettings.MailServer, this.emailSettings.MailPort, SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(this.emailSettings.Login, this.emailSettings.Password);
                    await client.SendAsync(mimeMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}