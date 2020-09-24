using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProject.Reposi
{
    public interface IInitialDb
    { 
      IList<Paragraph> GetInitialDBContent();
      IList<PriceList> GetInitialDBPriceLists();
    }
}
