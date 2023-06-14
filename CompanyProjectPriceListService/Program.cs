using CompanyProjectPriceListService.Infrastructure.DBContext;
using CompanyProjectPriceListService.Infrastructure.InitialDbContent;
using EntityFrameworkCore.UnitOfWork.Extensions;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var conString = new NpgsqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("ConnectionStringToPostgreSQL"))
{
    Host = builder.Configuration["DbHost"],
    Username = builder.Configuration["DbUserName"],
    Password = builder.Configuration["DbPassword"]
}.ConnectionString;

builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyProjectPriceListDbContext>(options =>
    options.UseNpgsql(conString, sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(CompanyProjectPriceListDbContext).Assembly.GetName().Name)));
builder.Services.AddScoped<IInitialDbContent, InitialDbContent>();
builder.Services.AddScoped<DbContext, CompanyProjectPriceListDbContext>();
builder.Services.AddUnitOfWork();
builder.Services.AddUnitOfWork<CompanyProjectPriceListDbContext>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
