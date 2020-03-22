using Enginex.Application.Categories.Queries;
using Enginex.Application.Localization;
using Enginex.Application.Mapping;
using Enginex.Application.Products.Queries;
using Enginex.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Category = Enginex.Application.Categories.Queries.Category;
using Product = Enginex.Application.Products.Queries.Product;

namespace Enginex.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient<ICurrentCulture, CurrentCulture>()
                .AddTransient<IMapper<Domain.Entities.Category, Category>, CategoryMapper>()
                .AddTransient<IMapper<Domain.Entities.Product, Product>, ProductMapper>()
                .AddTransient<IMapper<Domain.Entities.Product, ProductEdit>, ProductEditMapper>()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
