using Microsoft.AspNetCore.Mvc;
using RefitInterfaces;

namespace CompanyProject.API.Infrastructure.ViewComponents;

public class TypeOfFailure : ViewComponent
{
    private readonly IContentServicePriceList _contentServicePriceList;

    public TypeOfFailure(IContentServicePriceList contentService)
    {
        _contentServicePriceList = contentService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _contentServicePriceList.Get("typeoffailures");
        return View("TypeOfFailure", result);
    }
}