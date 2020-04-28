using Enginex.Application;
using Enginex.Domain;
using Enginex.Domain.Data;
using Enginex.Domain.FileService;
using Enginex.Infrastructure.Captcha;
using Enginex.Infrastructure.Email;
using Enginex.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
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

        public void ConfigureServices(IServiceCollection services)
        {
            // Infrastructure
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<ICaptcha, GoogleCaptcha>();
            services
                .AddApplication()
                .AddLocalization(options => options.ResourcesPath = "Resources")
                .AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            if (this.env.IsStaging())
            {
                services
                    .AddDbContextPool<AppDbContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0"));
            }
            else
            {
                services
                    .AddDbContextPool<AppDbContext>(options => options.UseSqlServer(this.configuration.GetConnectionString("EnginexDbConnection")));
            }

            services
                .AddTransient<IFileUpload, FileUpload>(provider => new FileUpload(this.env.WebRootPath))
                .AddTransient<IRepository, Repository>()
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services
                .AddAuthentication()
                .AddGoogle(options =>
                {
                    var googleAuthNSection = this.configuration.GetSection("Authentication:Google");
                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                });

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
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "products",
                    "product/list/{categoryId?}",
                    defaults: new { controller = "Product", action = "List" });

                endpoints.MapControllerRoute(
                    "adminProducts",
                    "admin/products/{categoryId?}",
                    defaults: new { controller = "Admin", action = "Products" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
