using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Infrastructure.Captcha;
using Enginex.Infrastructure.Email;
using Enginex.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enginex.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContextPool<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EnginexDbConnection")))
                .AddTransient<IRepository, Repository>()
                .AddSingleton<IEmailSender, EmailSender>()
                .AddSingleton<ICaptcha, GoogleCaptcha>();

            return services;
        }
    }
}
