using System.Threading.Tasks;
using CompanyProject.Domain.Interfaces;

namespace CompanyProject.Domain.Customer
{
    public interface ICustomersRepository:IGenericRepository<Customer>
    {
        public Task<Customer> GetCustomerByPhoneAsync(string phoneNumber);
    }
}