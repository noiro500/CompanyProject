using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Domain.CompanyContact
{
    public interface ICompanyContactsRepository:IGenericRepository<CompanyContact>
    {
        public Task<CompanyContact> GetToUseCompanyAsync(string parameter);
    }
}
