using CompanyProjectOrderService.Infrastructure.DBContext;
using EntityFrameworkCore.UnitOfWork.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyProjectOrderDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQL"], sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(CompanyProjectOrderDbContext).Assembly.GetName().Name)));
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
