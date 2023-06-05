using CompanyProjectPriceListService.Model;

namespace CompanyProjectPriceListService.Infrastructure.InitialDbContent;

public interface IInitialDbContent
{
   IList<PriceList> InitialDbPriceListContent();

}
