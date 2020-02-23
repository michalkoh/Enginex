namespace Enginex.Infrastructure.Email
{
    public class EmailSettings
    {
        public EmailSettings()
        {
            MailServer = string.Empty;
            SenderName = string.Empty;
            Sender = string.Empty;
            Password = string.Empty;
        }

        public string MailServer { get; set; }

        public int MailPort { get; set; }

        public string SenderName { get; set; }

        public string Sender { get; set; }

        public string Password { get; set; }
    }
}
