using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.Customer;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository.Repository
{
    public class CustomersRepository:GenericRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(CompanyProjectDbContext ctx) : base(ctx)
        {

        }

        public async Task<Customer> GetCustomerByPhoneAsync(string phoneNumber)
        {
            var result = await _context.Set<Customer>().AsNoTracking()
                .AsQueryable().FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
            return result;
        }
    }
}
