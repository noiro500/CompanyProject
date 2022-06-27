using System.Diagnostics;
using CompanyProjectContent.Models.Paragraph;
using System.Text.Json;
using CompanyProjectContent.Models.Page;

namespace CompanyProjectContent.Infrastructure.InitialDBContent;

public class InitialDbContent : IInitialDbContent
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public InitialDbContent(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment=webHostEnvironment;
    }
   
    public IList<Page> InitialDbPageContent()
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Resources", "DbSeed",
            "InitialDbPageContent.json");
        var jsonData = JsonSerializer.Deserialize<List<Page>>(File.ReadAllText(filePath));
        int i = 0;
        jsonData.ForEach(p => p.PageId = ++i);
        return jsonData;
    }
    public IList<Paragraph> InitialDbParagraphContent()
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Resources", "DbSeed",
            "InitialDbParagraphContent.json");
        var jsonData = JsonSerializer.Deserialize<List<Paragraph>>(File.ReadAllText(filePath));
        int i = 0;
        jsonData.ForEach(p => p.ParagraphId = ++i);
        return jsonData;
    }
}