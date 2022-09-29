using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using CompanyProject.Domain.AddressFromDb;
using CompanyProject.Domain.Paragraph;
using CompanyProject.Domain.PriceList;
using Microsoft.Extensions.FileProviders;

namespace CompanyProject.Repository.InitialDataBase
{
    public class InitialDb : IInitialDb
    {
        //public IList<Paragraph> GetInitialDbContent()
        //{
        //    IFileProvider getCurrentDirectory = new PhysicalFileProvider(Directory.GetCurrentDirectory());
        //    var jsonDesData = JsonSerializer.Deserialize<List<Paragraph>>(File.ReadAllText(getCurrentDirectory.GetFileInfo("/wwwroot/Resources/DbSeed/InitialDBContentNew.json").PhysicalPath));
        //    int i = 0;
        //    jsonDesData.ForEach(p => p.ParagraphId = ++i);
        //    return jsonDesData;

        //}

        //public IList<PriceList> GetInitialDbPriceLists()
        //{
        //    IFileProvider getCurrentDirectory = new PhysicalFileProvider(Directory.GetCurrentDirectory());
        //    var jsonDesData = JsonSerializer.Deserialize<List<PriceList>>(File.ReadAllText(getCurrentDirectory.GetFileInfo("/wwwroot/Resources/DbSeed/InitialDBPriceLists.json").PhysicalPath));
        //    int i = 0;
        //    jsonDesData.ForEach(p => p.PriceListId = ++i);
        //    return jsonDesData;
        //}

        public IList<AddressFromDb> GetInitialDbRealAddresses()
        {
            IFileProvider getCurrentDirectory = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            var jsonDesData = JsonSerializer.Deserialize<List<AddressFromDb>>(File.ReadAllText(getCurrentDirectory.GetFileInfo("/wwwroot/Resources/DbSeed/InitialDbAddressFromDb.json").PhysicalPath));
            int i = 0;
            jsonDesData.ForEach(p => p.AddressFromDbId = ++i);
            return jsonDesData;

        }

    }

}
