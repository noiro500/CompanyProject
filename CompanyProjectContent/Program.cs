using CompanyProjectContentService.CQRS.Handlers;
using CompanyProjectContentService.CQRS.Queries;
using CompanyProjectContentService.Infrastructure.DBContext;
using CompanyProjectContentService.Infrastructure.InitialDbContent;
using EntityFrameworkCore.UnitOfWork.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
#if DEBUG
var conString = new NpgsqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("ConnectionStringToPostgreSQL"))
{
    Host = builder.Configuration["DbHost"],
    Username = builder.Configuration["DbUserName"],
    Password = builder.Configuration["DbPassword"]
}.ConnectionString;
builder.Services.AddDbContext<CompanyProjectContentDbContext>(options =>
    options.UseNpgsql(conString, sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(CompanyProjectContentDbContext).Assembly.GetName().Name)));
#else
builder.Services.AddDbContext<CompanyProjectContentDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQL"], sqlOptions =>
            sqlOptions.MigrationsAssembly(typeof(CompanyProjectContentDbContext).Assembly.GetName().Name)));
#endif

builder.Services.AddControllers();
builder.Services.AddScoped<IInitialDbContent, InitialDbContent>();
builder.Services.AddScoped<DbContext, CompanyProjectContentDbContext>();
builder.Services.AddUnitOfWork();
builder.Services.AddUnitOfWork<CompanyProjectContentDbContext>();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();
