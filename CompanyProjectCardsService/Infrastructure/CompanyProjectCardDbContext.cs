using CompanyProjectCardsService.Model;
using CompanyProjectCardsService.Infrastructure.InitialDbContent;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CompanyProjectCardsService.Infrastructure;

public class CompanyProjectCardDbContext : DbContext
{
    private readonly IInitialDbContent _content;
    public CompanyProjectCardDbContext(DbContextOptions<CompanyProjectCardDbContext> options,
        IInitialDbContent ctn) : base(options)
    {
        _content = ctn;
    }
    public DbSet<MainCard> MainCards { get; set; }
    //public DbSet<CardFooterItem> CardFooterItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
       modelBuilder.Entity<MainCard>().HasData(
            _content.InitialDbMainCardsContent()
        );
        modelBuilder.Entity<CardFooterItem>().HasData(
            _content.InitialDbCardFooterItemContent()
        );
        
        modelBuilder.Entity<MainCard>()
            .HasMany(c => c.CardFooterItems)
            .WithOne();
    }
}