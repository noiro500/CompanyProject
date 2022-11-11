using CompanyProjectMessage.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectMessage.Infrastructure
{
    public class CompanyProjectMessageDbContext:DbContext
    {
        public CompanyProjectMessageDbContext(DbContextOptions<CompanyProjectMessageDbContext> options):base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }
    }
}
