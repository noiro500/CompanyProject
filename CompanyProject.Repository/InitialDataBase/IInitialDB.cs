﻿using CompanyProject.Domain.Paragraph;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.Domain.AddressFormDb;
using CompanyProject.Domain.PriceList;

namespace CompanyProject.Repository.InitialDataBase
{
    public interface IInitialDb
    {
        IList<Paragraph> GetInitialDbContent();
        IList<PriceList> GetInitialDbPriceLists();
        IList<AddressFormDb> GetInitialDbRealAddresses();
    }
}
