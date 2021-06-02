using System;
using System.Threading.Tasks;
using CompanyProject.Domain.AddressFromDb;
using CompanyProject.Domain.CompanyContact;
using CompanyProject.Domain.Customer;
using CompanyProject.Domain.Employee;
using CompanyProject.Domain.Feedback;
using CompanyProject.Domain.Message;
using CompanyProject.Domain.Order;
using CompanyProject.Domain.Page;
using CompanyProject.Domain.Paragraph;
using CompanyProject.Domain.PriceList;

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
        IAddressFromDbRepository AddressFromDbs { get; }
        Task CompleteAsync();
    }
}
