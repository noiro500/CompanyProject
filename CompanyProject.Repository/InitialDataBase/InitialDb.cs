using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CompanyProject.Domain.ParagraphAggregate;
using CompanyProject.Domain.PriceListAggregate;

namespace CompanyProject.Repository.InitialDataBase
{
    public class InitialDb : IInitialDb
    {
        //private readonly IWebHostEnvironment _environment;

        //public InitialDb(IWebHostEnvironment env)
        //{
        //    _environment = env;
        //}
        public IList<Paragraph> GetInitialDbContent()
        {
            //var path = Path.Combine(_environment.WebRootPath, @"Resources\InitialDbData\InitialDBContentNew.json");
            //var jsonData = JsonSerializer.Deserialize<List<Paragraph>>(File.ReadAllText(path));
            var jsonData = JsonSerializer.Deserialize<List<Paragraph>>(File.ReadAllText(Path.Combine("DbDataSeed", "InitialDBContentNew.json")));
            int i = 0;
            jsonData.ForEach(p => p.ParagraphId = ++i);
            return jsonData;
            //throw new System.NotImplementedException();

        }

        public IList<PriceList> GetInitialDbPriceLists()
        {
            //var path = Path.Combine(_environment.WebRootPath, @"Resources\InitialDbData\InitialDBPriceLists.json");
            //var jsonData = JsonSerializer.Deserialize<List<PriceList>>(File.ReadAllText(path));
            //int i = 0;
            //jsonData.ForEach(p => p.PriceListId = ++i);
            //return jsonData;
            throw new System.NotImplementedException();
        }
    }
}
