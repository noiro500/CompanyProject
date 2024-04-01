using Dto;
using Microsoft.AspNetCore.Mvc;
using RefitInterfaces;

namespace CompanyProject.API.Infrastructure.ViewComponents;

public class PriceListTable : ViewComponent
{
    private readonly IContentServicePriceList _contentServicePriceList;

    public PriceListTable(IContentServicePriceList contentService)
    {
        _contentServicePriceList = contentService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string pageName = "full")
    {
        var result = await _contentServicePriceList.GetPriceList(pageName);
        return View("PriceListTable", GetPriceListResultDic(ref result));
    }

    private IDictionary<string, List<PriceListDto>> GetPriceListResultDic(
        ref IList<PriceListDto> priceListResultFromService)
    {
        Dictionary<string, List<PriceListDto>> resultDictionary = new();
        var serviceName = priceListResultFromService.Select(x => x.ServiceName).Distinct().ToList();
        foreach (var usn in serviceName)
            resultDictionary.Add(usn, priceListResultFromService.Where(n => n.ServiceName == usn).ToList());
        return resultDictionary;
    }
}