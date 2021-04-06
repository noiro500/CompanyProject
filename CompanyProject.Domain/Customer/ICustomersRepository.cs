using System.Threading.Tasks;

namespace CompanyProject.Domain.Customer
{
    public interface ICustomersRepository:IGenericRepository<Customer>
    {
        public Task<Customer> GetCustomerByPhoneAsync(string phoneNumber);
    }
}