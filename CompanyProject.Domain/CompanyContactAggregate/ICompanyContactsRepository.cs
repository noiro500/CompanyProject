using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Domain.CompanyContactAggregate
{
    public interface ICompanyContactsRepository:IGenericRepository<CompanyContact>
    {
        public Task<CompanyContact> GetToUseAsync(string parameter);
    }
}
