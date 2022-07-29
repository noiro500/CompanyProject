using CompanyProjectCardsService.Model;
using CompanyProjectCardsService.Infrastructure.InitialDbContent;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectCardsService.Infrastructure;

public class CompanyProjectCardDbContext:DbContext
{
    private readonly IInitialDbContent _content;
    public CompanyProjectCardDbContext(DbContextOptions<CompanyProjectCardDbContext> options,
        IInitialDbContent ctn):base(options)
    {
        _content=ctn;
    }
    public DbSet<Card> Cards { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>().HasData(
            _content.InitialDbCardsContent()
        );
        modelBuilder.Entity<Card>().OwnsOne(u => u.CardFooter);
    }
}