using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Domain.PriceListAggregate
{
    public interface IPriceListsRepository:IGenericRepository<PriceList>
    {
        public Task<IDictionary<string, List<PriceList>>> GetPriceListByPageAsync(int pageNumber);
    }
    
}
