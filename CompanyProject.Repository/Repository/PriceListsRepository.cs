using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.PriceList;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository.Repository
{
    public class PriceListsRepository: GenericRepository<PriceList>, IPriceListsRepository
    {
        public PriceListsRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
        }

        public async Task<IDictionary<string, List<PriceList>>> GetPriceListByPageAsync(int pageNumber)
        {
            List<PriceList> priceListResultFromDb;
            if (pageNumber == 4)
            {
                priceListResultFromDb = await _context.PriceLists.Where(p => p.ServiceName == "Компьютерная помощь (компьютер)")
                    .OrderBy(x => x.PriceListId).ToListAsync();
                priceListResultFromDb.AddRange(await _context.PriceLists.Where(p => p.ServiceName == "Компьютерная помощь (ноутбук)")
                    .OrderBy(x => x.PriceListId).ToListAsync());
            }
            else
            {
                priceListResultFromDb = await _context.PriceLists.Where(p => p.Page.PageId == pageNumber)
                    .OrderBy(x => x.PriceListId).ToListAsync();
            }

            return GetPriceListResultDictionary(ref priceListResultFromDb);
        }

        public async Task<IDictionary<string, List<PriceList>>> GetFullPriceListAsync()
        {

            var priceListResultFromDb = await _context.PriceLists.OrderBy(x=>x.PriceListId).ToListAsync();
            return GetPriceListResultDictionary(ref priceListResultFromDb);
        }
        private IDictionary<string, List<PriceList>> GetPriceListResultDictionary( ref List<PriceList> priceListResultFromDb)
        {
            var resultDictionary = new Dictionary<string, List<PriceList>>();
            var serviceName = new List<string>();
            foreach (var priceList in priceListResultFromDb)
            {
                serviceName.Add(priceList.ServiceName);
            }

            var uniqueServiceName = serviceName.Distinct().ToList();
            //uniqueServiceName.Sort();
            foreach (var usn in uniqueServiceName)
            {
                resultDictionary.Add(usn, priceListResultFromDb.Where(n => n.ServiceName == usn).ToList());
            }

            return resultDictionary;
        }
    }
}
