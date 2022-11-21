using CompanyProject.Domain.Address;
using CompanyProject.Domain.AddressFromDb;
using CompanyProject.Domain.CompanyContact;
using CompanyProject.Domain.Customer;
using CompanyProject.Domain.Employee;
using CompanyProject.Domain.Feedback;
//using CompanyProject.Domain.Message;
using CompanyProject.Domain.Order;
using CompanyProject.Domain.Page;
using CompanyProject.Domain.Paragraph;
using CompanyProject.Domain.PriceList;
using CompanyProject.Repository.InitialDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class CompanyProjectDbContext : DbContext, IDataProtectionKeyContext
    {
        private readonly IInitialDb _context;
        public CompanyProjectDbContext(DbContextOptions<CompanyProjectDbContext> options, IInitialDb ctx) : base(options)
        {
            _context = ctx;
        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null;
        public DbSet<Page> Pages { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CompanyContact> CompanyContacts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        //public DbSet<Message> Messages { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<AddressFromDb> AddressFromDbs { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().OwnsOne(typeof(Address), "AddressData");
            modelBuilder.Entity<Page>().HasData(
                new Page[]
                {
                    new Page {PageId = 1, Name = "Index"},
                    new Page {PageId = 2, Name = "ComputersRepair", ScreenName = "Ремонт компьютеров", Icon ="fas fa-wrench", ToNavbar = true, ToCard = true, AspController = "Home"},
                    new Page {PageId = 3, Name = "LaptopsRepair", ScreenName = "Ремонт ноутбуков", Icon ="fas fa-laptop-medical", ToNavbar=true, ToCard = true, AspController = "Home"},
                    new Page {PageId = 4, Name = "HelpDesk", ScreenName = "Компьютерная помощь",Icon = "fas fa-ambulance", ToNavbar = true, ToCard = true, AspController = "Home"},
                    new Page {PageId = 5, Name = "InternetNetworks", ScreenName = "Интернет и сети", Icon = "fas fa-network-wired", ToNavbar = true, ToCard = true, AspController = "Home"},
                    new Page {PageId = 6, Name = "DataRecovery", ScreenName = "Восстановление данных", Icon = "fas fa-database", ToCard = true, AspController = "Home"},
                    new Page {PageId = 7, Name = "B2b", ScreenName = "ИТ-услуги для бизнеса", Icon = "fas fa-industry", ToNavbar = true, ToCard = true, AspController = "Home"},
                    new Page {PageId = 8, Name = "LaptopUpgrade", ScreenName = "Модернизация ноутбука", Icon = "fas fa-laptop", ToCard = true, AspController = "Home"},
                    new Page {PageId = 9, Name = "PcAssembly", ScreenName = "Сборка компьютера",Icon = "fas fa-tv", ToCard = true, AspController = "Home"},
                    new Page {PageId = 10, Name = "OfficeEquipment", ScreenName = "Oргтехника", Icon = "fas fa-print", ToNavbar = true, AspController = "Home"}
                }
            );

            //modelBuilder.Entity<Paragraph>().HasData(
            //    _context.GetInitialDbContent()
            //);

            //modelBuilder.Entity<PriceList>().HasData(
            //    _context.GetInitialDbPriceLists()
            //    );
            modelBuilder.Entity<AddressFromDb>().HasData(
                _context.GetInitialDbRealAddresses()
            );

            modelBuilder.Entity<CompanyContact>().HasData(
                new CompanyContact
                {
                    CompanyContactId = 1,
                    CompanyName = "<span class=\"has-text-black\">Нова<span> <span class=\"color-title\">Компьютерс</span>",
                    SimpleCompanyName = "Нова Компьютерс",
                    Address =
                        "РФ, Ставропольский край, Минераловодский городской округ, Населенный пункт, ул. Улица, дом 7а, офис 2",
                    PhoneNumber = "+7-(900)-000-00-00",
                    WhatsApp = "+7-(900)-000-00-00",
                    WorkTime = "9:00 - 19:00, выходные: восересенье, понедельник"
                }
            );
            modelBuilder.Entity<Paragraph>().HasIndex(p => p.Content);
            modelBuilder.Entity<Page>().HasIndex(p => p.Name);

            modelBuilder.Entity<Customer>().HasIndex(c => new { TelephoneNumber = c.PhoneNumber });
            modelBuilder.Entity<Order>().HasIndex(o => o.VisitTime);

            modelBuilder.Entity<Order>().Property(i => i.IsCompleted).HasDefaultValue(false);
            modelBuilder.Entity<Order>().Property(c => c.CreateTime).HasDefaultValue(DateTime.Today.ToString("g", new CultureInfo("ru-ru")));
            modelBuilder.Entity<Feedback>().HasIndex(i => new { i.FeedbackId, i.FeedbackText, i.Rating });
            modelBuilder.Entity<Feedback>().Property(r => r.Rating).HasMaxLength(1);
            modelBuilder.Entity<Feedback>().Property(f => f.FeedbackText).HasMaxLength(280);
            //modelBuilder.Entity<Message>().Property(p => p.Content).HasMaxLength(2000);
            //modelBuilder.Entity<Message>().Property(p => p.PeopleName).HasMaxLength(30);
            //modelBuilder.Entity<Message>().Property(p => p.SubjectMessage).HasMaxLength(50);

            modelBuilder.Entity<Order>().Navigation(e => e.AddressData).IsRequired();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(System.Console.WriteLine, LogLevel.Warning);
        }
    }
}
