using Microsoft.AspNetCore.Mvc;
using RefitInterfaces;

namespace CompanyProject.API.Infrastructure.ViewComponents;

public class Cards : ViewComponent
{
    private readonly IContentServiceCard _contentServiceCard;

    public Cards(IContentServiceCard contentService)
    {
        _contentServiceCard = contentService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string pageNameForCard)
    {
        var cardList = await _contentServiceCard.Get(pageNameForCard);
        return View("Cards", cardList);
    }
}