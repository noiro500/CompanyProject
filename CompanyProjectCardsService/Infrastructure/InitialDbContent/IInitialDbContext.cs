using CompanyProjectCardsService.Model;

namespace CompanyProjectCardsService.Infrastructure.InitialDbContent;

public interface IInitialDbContext
{
    IList<Card> InitialDbCardsContent();
}