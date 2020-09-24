using CompanyProject.Domain.ParagraphAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.Domain.PriceListAggregate;

namespace CompanyProject.Repository.InitialDataBase
{
    public interface IInitialDb
    { 
      IList<Paragraph> GetInitialDbContent();
      IList<PriceList> GetInitialDbPriceLists();
    }
}
