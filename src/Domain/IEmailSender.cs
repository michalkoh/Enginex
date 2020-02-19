using System.Threading.Tasks;

namespace Enginex.Domain
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
