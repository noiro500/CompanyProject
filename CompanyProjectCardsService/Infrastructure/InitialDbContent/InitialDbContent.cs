using CompanyProjectCardsService.Model;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace CompanyProjectCardsService.Infrastructure.InitialDbContent;

public class InitialDbContent : IInitialDbContent
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public InitialDbContent(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public IList<MainCard> InitialDbMainCardsContent()
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Resources", "DbSeed",
            "InitialDbMainCardContent.json");
        var resultData = JsonSerializer.Deserialize<List<MainCard>>(File.ReadAllText(filePath));
        int i = 0;
        resultData.ForEach(p => p.MainCardId =Guid.NewGuid());
        return resultData;
    }

    public IList<CardFooterItem> InitialDbCardFooterItemContent()
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Resources", "DbSeed",
            "InitialDbCardFooterItemContent.json");
        var resultData = JsonSerializer.Deserialize<List<CardFooterItem>>(File.ReadAllText(filePath));
        int i = 0;
        resultData.ForEach(p => p.CardFooterItemId = Guid.NewGuid());
        return resultData;
    }
}