using System.Configuration;
using CompanyProjectContent.Infrastructure;
using CompanyProjectContent.Infrastructure.InitialDBContent;
using Microsoft.EntityFrameworkCore;;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyProjectContentDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQLAzure"], sqlOptions =>
            sqlOptions.MigrationsAssembly(typeof(CompanyProjectContentDbContext).Assembly.GetName().Name)));

//builder.Services.AddScoped<DbContext, CompanyProjectContentDbContext>();
builder.Services.AddScoped<IInitialDbContent, InitialDbContent>();
var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();
