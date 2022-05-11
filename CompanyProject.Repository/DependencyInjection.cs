using CompanyProject.Domain;
using CompanyProject.Domain.Address;
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
using CompanyProject.ViewModels;
using FluentValidation;
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
            services.AddTransient<IValidator<Message>, MessageValidator>();
            services.AddTransient<IValidator<OrderViewModel>, OrderViewModelValidator>();
            services.AddTransient<IValidator<Address>, AddressValidator>();
            services.AddScoped<ICompanyContactsRepository, CompanyContactsRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();
            services.AddTransient<IFeedbacksRepository, FeedbacksRepository>();
            services.AddTransient<IMessagesRepository, MessagesRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IPagesRepository, PagesRepository>();
            services.AddScoped<IParagraphsRepository, ParagraphsRepository>();
            services.AddScoped<IPriceListsRepository, PriceListsRepository>();
            services.AddScoped<IAddressFromDbRepository, AddressFromDbRepository>();
            services.AddDbContext<CompanyProjectDbContext>(options =>
                options.UseNpgsql(configConnectionToDb, b => b.MigrationsAssembly("CompanyProject.API")));
#if RELEASE
            services.AddDataProtection()
                .PersistKeysToDbContext<CompanyProjectDbContext>();
#endif

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
