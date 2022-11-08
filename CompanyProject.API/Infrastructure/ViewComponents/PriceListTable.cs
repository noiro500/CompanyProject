using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.Dto;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using CompanyProject.Domain;
using CompanyProject.Domain.Interfaces;
using CompanyProject.Domain.PriceList;
using CompanyProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class PriceListTable : ViewComponent
    {
        private readonly IContentServicePriceList _contentServicePriceList;

        public PriceListTable(IContentServicePriceList contentService)
        {
            _contentServicePriceList = contentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string pageName = "full"/*, bool isFull = false*/)
        {
            var result = (await _contentServicePriceList.Get(pageName));
            return View("PriceListTable", GetPriceListResultDic(ref result));
        }

        private IDictionary<string, List<PriceListDto>> GetPriceListResultDic(ref IList<PriceListDto> priceListResultFromService)
        {
            Dictionary<string, List<PriceListDto>> resultDictionary = new();
            List<string> serviceName = new();
            foreach (var priceList in priceListResultFromService)
            {
                serviceName.Add(priceList.ServiceName);
            }

            var uniqueServiceName = serviceName.Distinct().ToList();
            foreach (var usn in uniqueServiceName)
            {
                resultDictionary.Add(usn, priceListResultFromService.Where(n => n.ServiceName == usn).ToList());
            }
            return resultDictionary;
        }
    }
}

