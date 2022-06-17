using CompanyProjectContent.Models.IndexPageCard;
using CompanyProjectContent.Models.Page;
using CompanyProjectContent.Models.Paragraph;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectContent.Infrastructure;

public class CompanyProjectContentDbContext:DbContext
{
    public CompanyProjectContentDbContext(DbContextOptions<CompanyProjectContentDbContext> options):base(options)
    {}
    
    public DbSet<IndexPageCard> IndexPageCards { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IndexPageCard>().HasKey(x => x.IndexPageCardId);
    }

}