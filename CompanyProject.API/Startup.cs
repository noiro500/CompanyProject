using CompanyProject.API.Infrastructure.Log;
using CompanyProject.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using AspNetCore.ReCaptcha;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using Microsoft.Extensions.FileProviders;
using Refit;
using CompanyProject.API.Infrastructure.HelpClasses;

namespace CompanyProject.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddFluentValidationAutoValidation();
            services.AddRepository(Configuration["ConnectionStrings:ConnectionStringToPostgreSQLAzure"]);
            services.AddCors();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddReCaptcha(Configuration.GetSection("ReCaptcha"));
            services.AddScoped<ICompanyInfo, CompanyInfo>();

            //services.AddHttpClient();
            services.AddRefitClient<IContentService>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri("http://localhost:5000/");
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            Log.LoggerFactory = loggerFactory;
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(builder => builder.WithOrigins("https://www.nova-computers.ru", "https://nova-computers.ru",
                "http://www.nova-computers.ru", "http://nova-computers.ru"));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
