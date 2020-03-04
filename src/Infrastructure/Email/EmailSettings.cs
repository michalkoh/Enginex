namespace Enginex.Infrastructure.Email
{
    public class EmailSettings
    {
        public EmailSettings()
        {
            MailServer = string.Empty;
            SenderName = string.Empty;
            To = string.Empty;
            Login = string.Empty;
            Password = string.Empty;
        }

        public string MailServer { get; set; }

        public int MailPort { get; set; }

        public string SenderName { get; set; }

        public string To { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
