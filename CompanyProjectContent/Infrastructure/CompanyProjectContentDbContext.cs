using CompanyProjectContentService.Infrastructure.InitialDbContent;
using CompanyProjectContentService.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectContentService.Infrastructure;

public class CompanyProjectContentDbContext : DbContext
{
    private readonly IInitialDbContent _content;

    public CompanyProjectContentDbContext(DbContextOptions<CompanyProjectContentDbContext> options,
        IInitialDbContent ctn) : base(options)
    {
        _content = ctn;
    }

    public DbSet<Page> Pages { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }
    public DbSet<TopMenuEntity> TopMenuEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Page>().HasData(
            _content.InitialContent<Page>("InitialDbPageContent.json"));
        modelBuilder.Entity<Paragraph>().HasData(
            _content.InitialContent<Paragraph>("InitialDbParagraphContent.json"));
        modelBuilder.Entity<TopMenuEntity>().HasData(
            _content.InitialContent<TopMenuEntity>("InitialDbTopMenuLineEntities.json"));

        modelBuilder.Entity<Paragraph>()
            .HasOne(p => p.Page)
            .WithMany(p => p.Paragraphs);
    }

}