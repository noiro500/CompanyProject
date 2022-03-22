using CompanyProject.Domain.User;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyProject.Repository.Repository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(CompanyProjectDbContext ctx) : base(ctx)
        {

        }

        public async Task<User> GetUserByPhoneAsync(string phoneNumber)
        {
            var result = await _context.Set<User>().AsNoTracking()
                .AsQueryable().FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
            return result;
        }
    }
}
