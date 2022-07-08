using CompanyProjectContentService.Infrastructure.InitialDbContent;
using CompanyProjectContentService.Models.Page;
using CompanyProjectContentService.Models.Paragraph;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectContentService.Infrastructure;

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
        modelBuilder.Entity<Paragraph>()
            .HasOne(p => p.Page)
            .WithMany(p => p.Paragraphs);


        //modelBuilder.Entity<IndexPageCard>().HasKey(x => x.IndexPageCardId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(System.Console.WriteLine, LogLevel.Warning);
    }
}