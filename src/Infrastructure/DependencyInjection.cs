using Enginex.Domain;
using Enginex.Infrastructure.Email;
using Microsoft.Extensions.DependencyInjection;

namespace Enginex.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddTransient<IRepository, InMemoryRepository>()
                .AddSingleton<IEmailSender, EmailSender>();

            return services;
        }
    }
}
