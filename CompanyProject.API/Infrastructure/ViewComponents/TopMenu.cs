using CompanyProject.API.Infrastructure.RefitInterfaces;
using Dto;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents;

public class TopMenu : ViewComponent
{
    private readonly IContentServiceContent _contentServiceContent;

    public TopMenu(IContentServiceContent contentService)
    {
        _contentServiceContent = contentService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var topMenuEntities = await _contentServiceContent.GetTopMenuEntitiesAsync();
        var topMenuFirstLine = topMenuEntities.Where(m => m.FirstLine).ToList();
        var topMenuNavBar = topMenuEntities.Where(m => m.NavBar).ToList();
        var topMenuDictionary = new Dictionary<string, List<TopMenuEntityDto>>
        {
            ["firstLine"] = topMenuFirstLine,
            ["topMenuNavBar"] = topMenuNavBar
        };
        return View("TopMenu", topMenuDictionary);
    }
}