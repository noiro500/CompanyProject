using CompanyProjectAddressService.Infrastructure.InitialDbContent;
using CompanyProjectAddressService.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectAddressService.Infrastructure
{
    public class CompanyProjectAddressDbContext: DbContext
    {
        private readonly IInitialDbContent _content;
        public CompanyProjectAddressDbContext(DbContextOptions<CompanyProjectAddressDbContext> options, IInitialDbContent ctn) : base(options)
        {
            _content=ctn;
        }
        public DbSet<AddressInDb> AddressInDataBase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressInDb>().HasData(
                _content.InitialContent<AddressInDb>("InitialDbAddressInDb.json"));
        }
    }
}
