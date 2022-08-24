using CompanyProjectPriceListService.Model;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;

namespace CompanyProjectPriceListService.Infrastructure.InitialDbContent;

public class InitialDbContent : IInitialDbContent
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public InitialDbContent(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment=webHostEnvironment;
    }

    public IList<PriceList> InitialDbPriceListContent()
    {
        IFileProvider getCurrentDirectory = new PhysicalFileProvider(Directory.GetCurrentDirectory());
        var jsonData = JsonSerializer.Deserialize<List<PriceList>>(File.ReadAllText(getCurrentDirectory.GetFileInfo("/wwwroot/Resources/DbSeed/InitialDBPriceLists.json").PhysicalPath));
        int i = 0;
        jsonData.ForEach(p => p.PriceListId = Guid.NewGuid());
        return jsonData;
    }
}