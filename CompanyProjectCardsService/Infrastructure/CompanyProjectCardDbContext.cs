using CompanyProjectCardsService.Model;
using CompanyProjectCardsService.Infrastructure.InitialDbContent;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectCardsService.Infrastructure;

public class CompanyProjectCardDbContext : DbContext
{
    private readonly IInitialDbContent _content;
    public CompanyProjectCardDbContext(DbContextOptions<CompanyProjectCardDbContext> options,
        IInitialDbContent ctn) : base(options)
    {
        _content = ctn;
    }
    public DbSet<Card> Cards { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Card>().HasData(
        //    _content.InitialDbCardsContent()
        //);
        modelBuilder.Entity<CardFooter>()
            .HasMany(p => p.CardFooterItems).WithOne();
        modelBuilder.Entity<Card>()
            .HasOne(c => c.CardFooter)
            .WithOne(c => c.Card)
            .HasForeignKey<CardFooter>(k => k.CardFooterForeignKey);
        modelBuilder.Entity<Card>()
            .HasOne(c => c.CardHeader)
            .WithOne(c => c.Card)
            .HasForeignKey<CardHeader>(k => k.CardHeaderForeignKey);
    }
}