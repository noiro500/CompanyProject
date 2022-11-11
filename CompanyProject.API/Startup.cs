using CompanyProject.API.Infrastructure.Log;
using Microsoft.AspNetCore.HttpOverrides;
using AspNetCore.ReCaptcha;
using CompanyProject.API.Infrastructure.Dto;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using CompanyProject.API.Infrastructure.HelpClasses;
using CompanyProject.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;

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
            services.AddFluentValidationClientsideAdapters();
            services.AddScoped<IValidator<MessageDto>, MessageDto.MessageValidator>();
            //services.AddRepository(Configuration["ConnectionStrings:ConnectionStringToPostgreSQL"]);
            services.AddCors();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddReCaptcha(Configuration.GetSection("ReCaptcha"));
            services.AddScoped<CompanyInfo>();
            services.AddRefitCollection(Configuration["UriApiGateway:URI"]!);
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
