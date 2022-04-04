using CompanyProject.Domain;
using CompanyProject.Domain.AddressFromDb;
using CompanyProject.Domain.CompanyContact;
using CompanyProject.Domain.Customer;
using CompanyProject.Domain.Employee;
using CompanyProject.Domain.Feedback;
using CompanyProject.Domain.Interfaces;
using CompanyProject.Domain.Message;
using CompanyProject.Domain.Order;
using CompanyProject.Domain.Page;
using CompanyProject.Domain.Paragraph;
using CompanyProject.Domain.PriceList;
using CompanyProject.Repository.InitialDataBase;
using CompanyProject.Repository.Repository;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyProject.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string configConnectionToDb)
        {
            services.AddSingleton<IInitialDb, InitialDb>();
            services.AddScoped<ICompanyContactsRepository, CompanyContactsRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();
            services.AddTransient<IFeedbacksRepository, FeedbacksRepository>();
            services.AddTransient<IMessagesRepository, MessagesRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IPagesRepository, PagesRepository>();
            services.AddTransient<IParagraphsRepository, ParagraphsRepository>();
            services.AddScoped<IPriceListsRepository, PriceListsRepository>();
            services.AddScoped<IAddressFromDbRepository, AddressFromDbRepository>();
            services.AddDbContext<CompanyProjectDbContext>(options =>
                options.UseNpgsql(configConnectionToDb, b => b.MigrationsAssembly("CompanyProject.API")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
