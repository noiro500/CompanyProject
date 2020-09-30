using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.CompanyContactAggregate;
using CompanyProject.Domain.CustomerAggregate;
using CompanyProject.Domain.EmployeeAggregate;
using CompanyProject.Domain.FeedbackAggregate;
using CompanyProject.Domain.MessageAggregate;
using CompanyProject.Domain.OrderAggregate;
using CompanyProject.Domain.PageAggregate;
using CompanyProject.Domain.ParagraphAggregate;
using CompanyProject.Domain.PriceListAggregate;

namespace CompanyProject.Domain
{
    public interface IUnitOfWork:IDisposable
    {
        ICompanyContactsRepository CompanyContacts { get; }
        ICustomersRepository Customers { get; }
        IEmployeesRepository Employees { get; }
        IFeedbacksRepository Feedbacks { get; }
        IMessagesRepository Messages { get; }
        IOrdersRepository Orders { get; }
        IPagesRepository Pages { get; }
        IParagraphsRepository Paragraphs { get; }
        IPriceListsRepository PriceLists { get; }
        Task<int> Complete();
    }
}
