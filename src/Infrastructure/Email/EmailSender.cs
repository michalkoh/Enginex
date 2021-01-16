using Enginex.Domain;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
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

        public Task SendEmailAsync(string to, string subject, string message)
        {
            return SendEmailAsync(string.Empty, to, subject, message);
        }

        public async Task SendEmailAsync(string from, string to, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(this.emailSettings.SenderName, this.emailSettings.Login));
                if (from != string.Empty)
                {
                    mimeMessage.From.Add(new MailboxAddress(from, from));
                }

                foreach (var toAddress in to.Split(';'))
                {
                    mimeMessage.To.Add(new MailboxAddress(toAddress, toAddress));
                }

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