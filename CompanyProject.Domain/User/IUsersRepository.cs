using System.Threading.Tasks;

namespace CompanyProject.Domain.User
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        public Task<User> GetUserByPhoneAsync(string phoneNumber);
    }
}
