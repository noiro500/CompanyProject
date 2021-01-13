using CompanyProject.Domain.Paragraph;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.Domain.PriceList;
using CompanyProject.Domain.RealAddress;

namespace CompanyProject.Repository.InitialDataBase
{
    public interface IInitialDb
    { 
      IList<Paragraph> GetInitialDbContent();
      IList<PriceList> GetInitialDbPriceLists();
      IList<RealAddress> GetInitialDbRealAddresses();
    }
}
