﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using CompanyProject.Domain.ParagraphAggregate;
using CompanyProject.Domain.PriceListAggregate;
using Microsoft.Extensions.FileProviders;

namespace CompanyProject.Repository.InitialDataBase
{
    public class InitialDb : IInitialDb
    {
        public IList<Paragraph> GetInitialDbContent()
        {
            IFileProvider getCurrentDirectory=new PhysicalFileProvider(Directory.GetCurrentDirectory());
            var jsonData = JsonSerializer.Deserialize<List<Paragraph>>(File.ReadAllText(getCurrentDirectory.GetFileInfo("/wwwroot/Resources/DbSeed/InitialDBContentNew.json").PhysicalPath));
            int i = 0;
            jsonData.ForEach(p => p.ParagraphId = ++i);
            return jsonData;
            //throw new System.NotImplementedException();

        }

        public IList<PriceList> GetInitialDbPriceLists()
        {
            IFileProvider getCurrentDirectory = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            var jsonData = JsonSerializer.Deserialize<List<PriceList>>(File.ReadAllText(getCurrentDirectory.GetFileInfo("/wwwroot/Resources/DbSeed/InitialDBPriceLists.json").PhysicalPath));
            int i = 0;
            jsonData.ForEach(p => p.PriceListId = ++i);
            return jsonData;
            //throw new System.NotImplementedException();
        }
    }
}