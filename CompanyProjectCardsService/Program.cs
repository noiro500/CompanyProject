using CompanyProjectCardsService.Infrastructure.InitialDbContent;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.UnitOfWork.Extensions;
using CompanyProjectCardsService.Infrastructure.DBContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyProjectCardDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionStringToPostgreSQL"], sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(CompanyProjectCardDbContext).Assembly.GetName().Name)));
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