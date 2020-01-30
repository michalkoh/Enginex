using Enginex.Application.Mapping;
using Enginex.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Enginex.Application.Categories.Queries;
using Enginex.Application.Localization;

namespace Enginex.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<ICurrentCulture, CurrentCulture>();
            services.AddTransient<IMapper<Category, CategoryViewModel>, CategoryViewModelMapper>();
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
