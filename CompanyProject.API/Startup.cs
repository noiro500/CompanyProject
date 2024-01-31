using AspNetCore.ReCaptcha;
using CompanyProject.API.Infrastructure.HelpClasses;
using CompanyProject.API.Infrastructure.Log;
using RefitInterfaces;
using Dto;
using FluentValidation;
//using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpOverrides;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using Blazorise.FluentValidation;
using System.Reflection;

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
        services.AddCors();
        services.AddControllersWithViews();
        //services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<MessageDto>();
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //services.AddScoped<IValidator<MessageDto>, MessageDtoValidator>();
        //services.AddScoped<IValidator<OrderViewModelDto>, OrderViewModelDto.OrderViewModelDtoValidator>();
        //services.AddScoped<IValidator<AddressDto>, AddressDto.AddressDtoValidator>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddReCaptcha(Configuration.GetSection("ReCaptcha"));
        services.AddScoped<CompanyInfo>();
        services.AddRefitCollection(Configuration["UriApiGateway:URI"]!);
        services.AddBlazorise(options =>
            {
                options.Immediate = false;
            })
            .AddBulmaProviders()
            .AddFontAwesomeIcons()
            .AddBlazoriseFluentValidation();
        services.AddServerSideBlazor();
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
        //app.UseCors(builder => builder.WithOrigins("https://www.nova-computers.ru", "https://nova-computers.ru",
        //    "http://www.nova-computers.ru", "http://nova-computers.ru", "http://localhost:5014"));
        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()/*AllowAnyMethod().WithHeaders("Access-Control-Allow-Origin")*/);
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapBlazorHub();
        });
        
    }
}