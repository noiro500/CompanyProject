using AspNetCore.ReCaptcha;
using CompanyProject.API.Infrastructure.Dto;
using CompanyProject.API.Infrastructure.HelpClasses;
using CompanyProject.API.Infrastructure.Log;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpOverrides;

namespace CompanyProject.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddFluentValidationClientsideAdapters();
        services.AddScoped<IValidator<MessageDto>, MessageDtoValidator>();
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
            app.UseDeveloperExceptionPage();
        else
            app.UseExceptionHandler("/Home/Error");
        app.UseStaticFiles();
        app.UseStatusCodePages();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCors(builder => builder.WithOrigins("https://www.nova-computers.ru", "https://nova-computers.ru",
            "http://www.nova-computers.ru", "http://nova-computers.ru"));
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}");
        });
    }
}