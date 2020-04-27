using System;
using System.IO;
using Autofac;
using MediatR;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SST.Application.Common.Interfaces;
using SST.Persistence;
using System.Reflection;
using SST.Application;
using SST.WebUI.Services;
using SST.Application.Common.Hashing;
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
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/Account/Login");
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

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<RazorViewToStringRenderer>();

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
            //builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            builder.RegisterModule<Application.DependencyModule>();

            AutofacContainer = builder.Build();

            return new AutofacServiceProvider(AutofacContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
