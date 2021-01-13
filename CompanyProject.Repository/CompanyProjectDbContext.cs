using System;
using System.Globalization;
using CompanyProject.Domain.CompanyContact;
using CompanyProject.Domain.Customer;
using CompanyProject.Domain.Employee;
using CompanyProject.Domain.Feedback;
using CompanyProject.Domain.Message;
using CompanyProject.Domain.Order;
using CompanyProject.Domain.Page;
using CompanyProject.Domain.Paragraph;
using CompanyProject.Domain.PriceList;
using CompanyProject.Domain.RealAddress;
using CompanyProject.Repository.InitialDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CompanyProject.Repository
{
    public class CompanyProjectDbContext:DbContext
    {
        private readonly IInitialDb _context;
        public CompanyProjectDbContext(DbContextOptions<CompanyProjectDbContext> options, IInitialDb ctx) : base(options)
        {
            _context = ctx;
        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CompanyContact> CompanyContacts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<RealAddress> RealAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>()
                .HasMany(p => p.Paragraphs)
                .WithOne(p => p.Page);

            modelBuilder.Entity<PriceList>()
                .HasOne(p => p.Page)
                .WithMany(p => p.PriceLists);

            modelBuilder.Entity<Customer>()
                .HasMany(o => o.Orders)
                .WithOne(c => c.Customer);
            modelBuilder.Entity<Employee>()
                .HasMany(o => o.Orders)
                .WithOne(e => e.Employee);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Feedback)
                .WithOne(i => i.Order)
                .HasForeignKey<Feedback>(o => o.OrderForeignKey);

            modelBuilder.Entity<EmployeeCustomer>()
                .HasKey(t => new { t.EmployeeId, t.CustomerId });
            modelBuilder.Entity<EmployeeCustomer>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.EmployeeCustomers)
                .HasForeignKey(c => c.EmployeeId);
            modelBuilder.Entity<EmployeeCustomer>()
                .HasOne(c => c.Customer)
                .WithMany(e => e.EmployeeCustomers)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<Page>().HasData(
                new Page[]
                {
                    new Page {PageId = 1, Name = "Index"},
                    new Page {PageId = 2, Name = "ComputersRepair", ScreenName = "Ремонт компьютеров", Icon ="fas fa-wrench", ToNavbar = true, ToCard = true},
                    new Page {PageId = 3, Name = "LaptopsRepair", ScreenName = "Ремонт ноутбуков", Icon ="fas fa-laptop-medical", ToNavbar=true, ToCard = true},
                    new Page {PageId = 4, Name = "HelpDesk", ScreenName = "Компьютерная помощь",Icon = "fas fa-ambulance", ToCard = true},
                    new Page {PageId = 5, Name = "InternetNetworks", ScreenName = "Интернет и сети", Icon = "fas fa-network-wired", ToNavbar = true, ToCard = true},
                    new Page {PageId = 6, Name = "DataRecovery", ScreenName = "Восстановление данных", Icon = "fas fa-database", ToCard = true},
                    new Page {PageId = 7, Name = "B2b", ScreenName = "ИТ-услуги для бизнеса", Icon = "fas fa-industry", ToNavbar = true, ToCard = true},
                    new Page {PageId = 8, Name = "LaptopUpgrade", ScreenName = "Модернизация ноутбука", Icon = "fas fa-laptop", ToCard = true},
                    new Page {PageId = 9, Name = "PcAssembly", ScreenName = "Сборка компьютера",Icon = "fas fa-tv", ToCard = true},
                    new Page {PageId = 10, Name = "OfficeEquipment", ScreenName = "Oргтехника", Icon = "fas fa-print", ToNavbar = true}
                }
            );

            modelBuilder.Entity<Paragraph>().HasData(
                _context.GetInitialDbContent()
            );

            modelBuilder.Entity<PriceList>().HasData(
                _context.GetInitialDbPriceLists()
                );
            modelBuilder.Entity<RealAddress>().HasData(
                _context.GetInitialDbRealAddresses()
            );

            modelBuilder.Entity<CompanyContact>().HasData(
                new CompanyContact
                {
                    CompanyContactId = 1,
                    CompanyName = "<span class=\"has-text-black\">Нова<span> <span class=\"color-title\">Компьютерс</span>",
                    Address =
                        "РФ, Ставропольский край, Минераловодский городской округ, п. Бородыновка, ул. Железнодорожная 7а, 2",
                    PhoneNumber = "+7-(900)-000-00-00",
                    WhatsApp = "+7-(900)-000-00-00"
                }
            );

            modelBuilder.Entity<Paragraph>().HasIndex(p => p.Content);
            modelBuilder.Entity<Page>().HasIndex(p => p.Name);

            modelBuilder.Entity<Customer>().HasIndex(c => new { TelephoneNumber = c.PhoneNumber/*, c.Address*/ });
            modelBuilder.Entity<Order>().HasIndex(o => o.VisitTime);

            modelBuilder.Entity<Order>().Property(i => i.IsCompleted).HasDefaultValue(false);
            modelBuilder.Entity<Order>().Property(c => c.CreateTime).HasDefaultValue(DateTime.Today.ToString("g", new CultureInfo("ru-ru")));
            modelBuilder.Entity<Feedback>().HasIndex(i => new { i.FeedbackId, i.FeedbackText, i.Rating });
            modelBuilder.Entity<Feedback>().Property(r => r.Rating).HasMaxLength(1);
            modelBuilder.Entity<Feedback>().Property(f => f.FeedbackText).HasMaxLength(280);
            modelBuilder.Entity<Message>().Property(p => p.Content).HasMaxLength(2000);

        }
    }
}
