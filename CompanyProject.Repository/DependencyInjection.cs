using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain;
using CompanyProject.Domain.CompanyContact;
using CompanyProject.Domain.Customer;
using CompanyProject.Domain.Employee;
using CompanyProject.Domain.Feedback;
using CompanyProject.Domain.Message;
using CompanyProject.Domain.Order;
using CompanyProject.Domain.Page;
using CompanyProject.Domain.Paragraph;
using CompanyProject.Domain.PriceList;
using CompanyProject.Repository.InitialDataBase;
using CompanyProject.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CompanyProject.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string configConnectionToDb)
        {
            services.AddSingleton<IInitialDb, InitialDb>();
            services.AddTransient<ICompanyContactsRepository, CompanyContactsRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();
            services.AddTransient<IFeedbacksRepository, FeedbacksRepository>();
            services.AddTransient<IMessagesRepository, MessagesRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IPagesRepository, PagesRepository>();
            services.AddTransient<IParagraphsRepository, ParagraphsRepository>();
            services.AddTransient<IPriceListsRepository, PriceListsRepository>();
            services.AddDbContext<CompanyProjectDbContext>(options =>
                options.UseLazyLoadingProxies().UseNpgsql(configConnectionToDb, b=>b.MigrationsAssembly("CompanyProject.API")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
