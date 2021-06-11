using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain;
using CompanyProject.Domain.CompanyContact;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository.Repository
{
    public class CompanyContactsRepository : GenericRepository<CompanyContact>, ICompanyContactsRepository
    {
        public CompanyContactsRepository(CompanyProjectDbContext ctx) : base(ctx)
        {

        }

        public async Task<CompanyContact> GetToUseCompanyAsync(string parameter)
        {
            if (parameter.Equals("ToUse"))
            {
                return await (_context.Set<CompanyContact>().AsNoTracking())
                    .FirstOrDefaultAsync(c => c.ToUse);
            }
            else return null;
        }
        public CompanyContact GetToUseCompany(string parameter)
        {
            if (parameter.Equals("ToUse"))
            {
                return (_context.Set<CompanyContact>().AsNoTracking())
                    .FirstOrDefault(c => c.ToUse);
            }
            else return null;
        }
    }
}
