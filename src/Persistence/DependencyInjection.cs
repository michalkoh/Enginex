using Enginex.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Enginex.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IRepository, InMemoryRepository>();

            return services;
        }
    }
}
