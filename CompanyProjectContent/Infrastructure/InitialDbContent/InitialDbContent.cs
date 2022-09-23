﻿using System.Text.Json;
using CompanyProjectContentService.Models.Page;
using CompanyProjectContentService.Models.Paragraph;
using CompanyProjectContentService.Models.TopMenu;

namespace CompanyProjectContentService.Infrastructure.InitialDbContent;

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
        var resultData = JsonSerializer.Deserialize<List<Page>>(File.ReadAllText(filePath));
        int i = 0;
        resultData.ForEach(p => p.PageId = ++i);
        return resultData;
    }
    public IList<Paragraph> InitialDbParagraphContent()
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Resources", "DbSeed",
            "InitialDbParagraphContent.json");
        var resultData = JsonSerializer.Deserialize<List<Paragraph>>(File.ReadAllText(filePath));
        int i = 0;
        resultData.ForEach(p => p.ParagraphId = ++i);
        return resultData;
    }

    public IList<TopMenuEntity> InitialDbTopMenuEntities()
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Resources", "DbSeed",
            "InitialDbTopMenuLineEntities.json");
        var resultData = JsonSerializer.Deserialize<List<TopMenuEntity>>(File.ReadAllText(filePath));
        resultData.ForEach(p => p.TopMenuEntityId = Guid.NewGuid());
        return resultData;
    }
}