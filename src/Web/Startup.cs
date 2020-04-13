using Enginex.Application;
using Enginex.Infrastructure;
using Enginex.Infrastructure.Captcha;
using Enginex.Infrastructure.Email;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;

namespace Enginex.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddApplication()
                .AddInfrastructure(this.env.IsStaging() ? string.Empty : this.configuration.GetConnectionString("EnginexDbConnection"))
                .AddLocalization(options => options.ResourcesPath = "Resources")
                .AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            var supportedCultures = new[]
            {
                new CultureInfo("sk"),
                new CultureInfo("en")
            };

            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => false;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                })
                .Configure<RequestLocalizationOptions>(options =>
                {
                    options.DefaultRequestCulture = new RequestCulture("sk");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders = new List<IRequestCultureProvider>
                    {
                        new CookieRequestCultureProvider()
                    };
                })
                .Configure<RouteOptions>(options => options.LowercaseUrls = true)
                .Configure<EmailSettings>(this.configuration.GetSection("EmailSettings"))
                .Configure<GoogleCaptchaSettings>(this.configuration.GetSection("GoogleCaptchaSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (this.env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseRequestLocalization();
            ////app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            ////app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "category",
                    "product/list/{categoryId?}",
                    defaults: new { controller = "Product", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
