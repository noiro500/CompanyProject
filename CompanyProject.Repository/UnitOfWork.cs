using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain;
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
using Microsoft.EntityFrameworkCore.Internal;

namespace CompanyProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyProjectDbContext _context;
        public ICompanyContactsRepository CompanyContacts { get; }

        public ICustomersRepository Customers { get; }

        public IEmployeesRepository Employees { get; }

        public IFeedbacksRepository Feedbacks { get; }

        public IMessagesRepository Messages { get; }

        public IOrdersRepository Orders { get; }

        public IPagesRepository Pages { get; }

        public IParagraphsRepository Paragraphs { get; }

        public IPriceListsRepository PriceLists { get; }
        public UnitOfWork(CompanyProjectDbContext context)
        {
            _context = context;
            this.CompanyContacts = new CompanyContactsRepository(_context);
            this.Customers = new CustomersRepository(_context);
            this.Employees = new EmployeesRepository(_context);
            this.Feedbacks = new FeedbacksRepository(_context);
            this.Messages = new MessagesRepository(_context);
            this.Orders = new OrdersRepository(_context);
            this.Pages = new PagesRepository(_context);
            this.Paragraphs = new ParagraphsRepository(_context);
            this.PriceLists = new PriceListsRepository(_context);
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();

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
