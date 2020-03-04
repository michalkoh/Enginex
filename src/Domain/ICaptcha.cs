using System.Threading.Tasks;

namespace Enginex.Domain
{
    public interface ICaptcha
    {
        Task<bool> IsValid(string? response, string? remoteIpAddress);
    }
}
