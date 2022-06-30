using System.Configuration;
using System.Text.Json.Serialization;
using CompanyProjectContent.Infrastructure;
using CompanyProjectContent.Infrastructure.InitialDBContent;
using EntityFrameworkCore.UnitOfWork.Extensions;
using Microsoft.EntityFrameworkCore;;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers()
    /*.AddJsonOptions(options=>
        options.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles)*/;
builder.Services.AddDbContext<CompanyProjectContentDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQLAzure"], sqlOptions =>
            sqlOptions.MigrationsAssembly(typeof(CompanyProjectContentDbContext).Assembly.GetName().Name)));


builder.Services.AddScoped<IInitialDbContent, InitialDbContent>();
builder.Services.AddScoped<DbContext, CompanyProjectContentDbContext>();
builder.Services.AddUnitOfWork();
builder.Services.AddUnitOfWork<CompanyProjectContentDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();
