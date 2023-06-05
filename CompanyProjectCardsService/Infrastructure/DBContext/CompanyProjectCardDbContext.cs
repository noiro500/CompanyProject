using CompanyProjectCardsService.Model;
using CompanyProjectCardsService.Infrastructure.InitialDbContent;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CompanyProjectCardsService.Infrastructure.DBContext;

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
             _content.InitialContent<MainCard>("InitialDbMainCardContent.json")
         );
        modelBuilder.Entity<CardFooterItem>().HasData(
            _content.InitialContent<CardFooterItem>("InitialDbCardFooterItemContent.json")
        );

        modelBuilder.Entity<MainCard>()
            .HasMany(c => c.CardFooterItems)
            .WithOne();
        modelBuilder.Entity<MainCard>().HasIndex(p => p.PageNameForCard);
    }
}