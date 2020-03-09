using Enginex.Application.Categories.Queries;
using Enginex.Application.Localization;
using Enginex.Application.Mapping;
using Enginex.Application.Products.Queries;
using Enginex.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Enginex.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient<ICurrentCulture, CurrentCulture>()
                .AddTransient<IMapper<Category, CategoryDto>, CategoryDtoMapper>()
                .AddTransient<IMapper<Product, ProductDto>, ProductDtoMapper>()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
