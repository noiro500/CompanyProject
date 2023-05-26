using CompanyProjectOrderService.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectOrderService.Infrastructure.DBContext
{
    public class CompanyProjectOrderDbContext: DbContext
    {
        public CompanyProjectOrderDbContext(DbContextOptions<CompanyProjectOrderDbContext> options):base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().UseTpcMappingStrategy();
        }
    }
}
