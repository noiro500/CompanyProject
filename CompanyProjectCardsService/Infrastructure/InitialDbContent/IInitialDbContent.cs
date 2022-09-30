using CompanyProjectCardsService.Model;

namespace CompanyProjectCardsService.Infrastructure.InitialDbContent;

public interface IInitialDbContent
{
    IList<MainCard> InitialDbMainCardsContent();
    IList<CardFooterItem> InitialDbCardFooterItemContent();

    IList<T> InitialContent<T>(string jsonFile) where T : new();
}