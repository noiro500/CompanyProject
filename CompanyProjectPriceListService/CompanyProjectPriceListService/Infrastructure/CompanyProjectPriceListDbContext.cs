using CompanyProjectPriceListService.Infrastructure.InitialDbContent;
using CompanyProjectPriceListService.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectPriceListService.Infrastructure;

public class CompanyProjectPriceListDbContext:DbContext
{
    private readonly IInitialDbContent _content;
    public CompanyProjectPriceListDbContext(DbContextOptions<CompanyProjectPriceListDbContext> options,
        IInitialDbContent ctn) :base(options)
    {
        _content=ctn;
    }
    public DbSet<PriceList> PriceLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriceList>().HasData(
        _content.InitialDbPriceListContent());
    }
}