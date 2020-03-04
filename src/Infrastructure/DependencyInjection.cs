using Enginex.Domain;
using Enginex.Infrastructure.Captcha;
using Enginex.Infrastructure.Email;
using Enginex.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Enginex.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddTransient<IRepository, InMemoryRepository>()
                .AddSingleton<IEmailSender, EmailSender>()
                .AddSingleton<ICaptcha, GoogleCaptcha>();

            return services;
        }
    }
}
