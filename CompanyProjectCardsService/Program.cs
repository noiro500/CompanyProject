using CompanyProjectCardsService.Infrastructure.InitialDbContent;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.UnitOfWork.Extensions;
using CompanyProjectCardsService.Infrastructure.DBContext;
using Npgsql;

#if DEBUG
var builder = WebApplication.CreateBuilder(args);
var conString = new NpgsqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("ConnectionStringToPostgreSQL"))
{
    Host = builder.Configuration["DbHost"],
    Username = builder.Configuration["DbUserName"],
    Password = builder.Configuration["DbPassword"]
}.ConnectionString;
builder.Services.AddDbContext<CompanyProjectCardDbContext>(options =>
    options.UseNpgsql(conString, sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(CompanyProjectCardDbContext).Assembly.GetName().Name)));
#else
builder.Services.AddDbContext<CompanyProjectCardDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQL"], sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(CompanyProjectCardDbContext).Assembly.GetName().Name)));
#endif



builder.Services.AddControllers();

builder.Services.AddScoped<IInitialDbContent, InitialDbContent>();
builder.Services.AddScoped<DbContext, CompanyProjectCardDbContext>();
builder.Services.AddUnitOfWork();
builder.Services.AddUnitOfWork<CompanyProjectCardDbContext>();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.MapControllers();
app.Run();