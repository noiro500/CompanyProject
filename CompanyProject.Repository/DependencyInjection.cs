using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.CompanyContactAggregate;
using CompanyProject.Domain.CustomerAggregate;
using CompanyProject.Domain.EmployeeAggregate;
using CompanyProject.Domain.FeedbackAggregate;
using CompanyProject.Domain.MessageAggregate;
using CompanyProject.Domain.OrderAggregate;
using CompanyProject.Domain.PageAggregate;
using CompanyProject.Domain.ParagraphAggregate;
using CompanyProject.Domain.PriceListAggregate;
using CompanyProject.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CompanyProject.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string configConnectionToDb)
        {
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
                options.UseNpgsql(configConnectionToDb));
            return services;
        }
    }
}
