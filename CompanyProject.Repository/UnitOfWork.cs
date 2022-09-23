using CompanyProject.Domain;
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
using CompanyProject.Repository.Repository;
using System;
using System.Data;
using System.Threading.Tasks;
using CompanyProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyProjectDbContext _context;

        public UnitOfWork(CompanyProjectDbContext context)
        {
            _context = context;
            CompanyContacts = new CompanyContactsRepository(_context);
            Customers = new CustomersRepository(_context);
            Employees = new EmployeesRepository(_context);
            Feedbacks = new FeedbacksRepository(_context);
            Messages = new MessagesRepository(_context);
            Orders = new OrdersRepository(_context);
            //Pages = new PagesRepository_IsNotUsed(_context);
            //Paragraphs = new ParagraphsRepository_IsNotUsed(_context);
            //PriceLists = new PriceListsRepository_NotUsed(_context);
            AddressFromDbs = new AddressFromDbRepository(_context);
        }

        public ICompanyContactsRepository CompanyContacts { get; }

        public ICustomersRepository Customers { get; }

        public IEmployeesRepository Employees { get; }

        public IFeedbacksRepository Feedbacks { get; }

        public IMessagesRepository Messages { get; }

        public IOrdersRepository Orders { get; }

        public IPagesRepository Pages { get; }

        public IParagraphsRepository Paragraphs { get; }

        public IPriceListsRepository PriceLists { get; }

        public IAddressFromDbRepository AddressFromDbs { get; }



        public async Task CompleteAsync()
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.RepeatableRead);
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}