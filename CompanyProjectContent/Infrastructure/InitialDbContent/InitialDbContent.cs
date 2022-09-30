using System.Collections;
using System.Text.Json;
using CompanyProjectContentService.Models;
using System.Reflection;
using System.Linq;

namespace CompanyProjectContentService.Infrastructure.InitialDbContent;

public class InitialDbContent : IInitialDbContent
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public InitialDbContent(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment=webHostEnvironment;
    }
   
    public IList<T> InitialContent<T>(string jsonFile) where T : new()
    {
        var myType=typeof(T);
        var tProp = myType.GetProperties();
        var w = tProp.FirstOrDefault (x => x.Name.Contains(myType.Name+"Id")) 
                ?? throw new ArgumentNullException("tProp.FirstOrDefault (x => x.Name.Contains(myType.Name+\"Id\"))");
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Resources", "DbSeed",
            jsonFile);
        var resultData = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(filePath));
        int i = 0;
        resultData!.ForEach(p=>w.SetValue(p, ++i) );
        return resultData;
    }
}