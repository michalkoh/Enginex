using System.Threading.Tasks;

namespace Enginex.Domain
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string message);

        Task SendEmailAsync(string from, string to, string subject, string message);
    }
}
