using CompanyProjectOrderService.Infrastructure.DBContext;
using EntityFrameworkCore.UnitOfWork.Extensions;
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
builder.Services.AddDbContext<CompanyProjectOrderDbContext>(options =>
    options.UseNpgsql(conString/*builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQL"]*/, sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(CompanyProjectOrderDbContext).Assembly.GetName().Name)));
#else
builder.Services.AddDbContext<CompanyProjectOrderDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQL"], sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(CompanyProjectOrderDbContext).Assembly.GetName().Name)));
#endif

builder.Services.AddControllers();

builder.Services.AddScoped<DbContext, CompanyProjectOrderDbContext>();
builder.Services.AddUnitOfWork();
builder.Services.AddUnitOfWork<CompanyProjectOrderDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();

app.MapControllers();

app.Run();
