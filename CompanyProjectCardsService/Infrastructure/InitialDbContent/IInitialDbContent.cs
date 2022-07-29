using CompanyProjectCardsService.Model;

namespace CompanyProjectCardsService.Infrastructure.InitialDbContent;

public interface IInitialDbContent
{
    IList<Card> InitialDbCardsContent();
}