using CompanyProject.API.Infrastructure.HelpClasses;
using Microsoft.AspNetCore.Mvc;
using RefitInterfaces;

namespace CompanyProject.API.Controllers;

public class MenuFirstLineController : Controller
{
    private readonly IContentServiceContent _contentServiceContent;
    private readonly IContentServicePriceList _contentServicePriceList;

    public MenuFirstLineController(IContentServicePriceList contentServiceProList,
        IContentServiceContent contentServiceContent)
    {
        //_unitOfWork = unitOfWork;
        _contentServicePriceList = contentServiceProList;
        _contentServiceContent = contentServiceContent;
    }

    [Route("/comments")]
    public IActionResult Comments()
    {
        return View();
    }

    /// <summary>
    ///     Возвращает fullpricelist из микросервиса CompanyProjectPriceListService
    /// </summary>
    /// <returns>Спикок PriceListDto</returns>
    [Route("/fullpricelist")]
    public async Task<IActionResult> FullPriceList()
    {
        var result = (await _contentServicePriceList.Get("full")).OrderBy(p => p.PriceListId)
            .Distinct(new PriceListDtoComparer()).ToList();
        return View(result);
    }

    [Route("/about")]
    public async Task<IActionResult> About()
    {
        var companyInfo = await _contentServiceContent.GetCompanyContactAsync(true);
        return View("About", companyInfo);
    }

    [Route("/contacts")]
    public async Task<IActionResult> Contacts()
    {
        var companyInfo = await _contentServiceContent.GetCompanyContactAsync(true);
        return View("Contacts", companyInfo);
    }
}