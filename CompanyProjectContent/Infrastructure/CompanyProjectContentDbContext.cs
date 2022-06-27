using CompanyProjectContent.Infrastructure.InitialDBContent;
using CompanyProjectContent.Models.IndexPageCard;
using CompanyProjectContent.Models.Page;
using CompanyProjectContent.Models.Paragraph;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectContent.Infrastructure;

public class CompanyProjectContentDbContext:DbContext
{
    private readonly IInitialDbContent _content;

    public CompanyProjectContentDbContext(DbContextOptions<CompanyProjectContentDbContext> options,
        IInitialDbContent ctn) : base(options)
    {
        _content=ctn;
    }
    
    //public DbSet<IndexPageCard> IndexPageCards { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Page>().HasData(
            _content.InitialDbPageContent()
        );
        modelBuilder.Entity<Paragraph>().HasData(
            _content.InitialDbParagraphContent()
        );

        //modelBuilder.Entity<IndexPageCard>().HasKey(x => x.IndexPageCardId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(System.Console.WriteLine, LogLevel.Warning);
    }
}