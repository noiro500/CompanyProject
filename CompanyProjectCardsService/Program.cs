using CompanyProjectCardsService.Infrastructure;
using CompanyProjectCardsService.Infrastructure.InitialDbContent;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.UnitOfWork.Extensions;
using CompanyProjectCardsService.Model;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyProjectCardDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQLAzure"], sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(CompanyProjectCardDbContext).Assembly.GetName().Name)));
builder.Services.AddScoped<IInitialDbContent, InitialDbContent>();
builder.Services.AddScoped<DbContext, CompanyProjectCardDbContext>();
builder.Services.AddUnitOfWork();
builder.Services.AddUnitOfWork<CompanyProjectCardDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();
app.Run();