using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Infrastructure.Captcha;
using Enginex.Infrastructure.Email;
using Enginex.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Enginex.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services
                .AddSingleton<IEmailSender, EmailSender>()
                .AddSingleton<ICaptcha, GoogleCaptcha>();

            if (string.IsNullOrEmpty(connectionString))
            {
                services
                    .AddTransient<IRepository, InMemoryRepository>();
            }
            else
            {
                services
                    .AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connectionString))
                    .AddTransient<IRepository, Repository>()
                    .AddIdentityCore<IdentityUser>()
                    .AddEntityFrameworkStores<AppDbContext>();
            }

            return services;
        }
    }
}
