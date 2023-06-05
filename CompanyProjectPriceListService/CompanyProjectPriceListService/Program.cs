using CompanyProjectPriceListService.Infrastructure.DBContext;
using CompanyProjectPriceListService.Infrastructure.InitialDbContent;
using EntityFrameworkCore.UnitOfWork.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyProjectPriceListDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQL"], sqlOptions =>
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
