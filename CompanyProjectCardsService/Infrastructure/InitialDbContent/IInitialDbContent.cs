using CompanyProjectCardsService.Model;

namespace CompanyProjectCardsService.Infrastructure.InitialDbContent;

public interface IInitialDbContent
{
    IList<MainCard> InitialDbMainCardsContent();
    IList<CardFooterItem> InitialDbCardFooterItemContent();
}