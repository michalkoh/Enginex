using Enginex.Domain;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;
using MailKit.Security;

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
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(this.emailSettings.SenderName, this.emailSettings.Sender));
                mimeMessage.To.Add(new MailboxAddress(email));
                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    // lient.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(this.emailSettings.MailServer, this.emailSettings.MailPort, SecureSocketOptions.SslOnConnect);

                    //await client.ConnectAsync(this.emailSettings.MailServer, this.emailSettings.MailPort, true);
                    //await client.ConnectAsync(this.emailSettings.MailServer);

                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync(this.emailSettings.Sender, this.emailSettings.Password);
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