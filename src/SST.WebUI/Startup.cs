using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SST.Application;
using SST.Application.Common.Hashing;
using SST.Application.Common.Interfaces;
using SST.Persistence;
using SST.WebUI.Hubs;
using SST.WebUI.Services;
using SST.WebUI.Services.RazorToStringExample;

namespace SST.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Error/403");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("Admin")));
                options.AddPolicy("Student", policy =>
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("Student")));
                options.AddPolicy("Lector", policy =>
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("Lector")));
            });

            services.AddSignalR();
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
            services.AddControllersWithViews();
            services.AddTransient<RazorViewToStringRenderer>();
            services.AddSingleton<NotificationHub>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SSTDbContext>(options => options.UseSqlServer(connectionString));

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterType<SSTDbContext>().As<ISSTDbContext>().SingleInstance();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>();

            builder.RegisterModule<Application.DependencyModule>();

            AutofacContainer = builder.Build();

            return new AutofacServiceProvider(AutofacContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Home}/{id?}");
                endpoints.MapHub<NotificationHub>(
                    "/notify");

                    // options =>
                    // {
                    //    options.LongPolling.PollTimeout = TimeSpan.FromSeconds(10);
                    //    options.Transports = HttpTransportType.LongPolling;
                    // });
            });
        }
    }
}
