using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.Domain;
using CompanyProject.Domain.PriceList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class PriceListTable : ViewComponent
    {
        //private readonly IPriceListRepository repository;
        private readonly IUnitOfWork _unitOfWork;

        public PriceListTable(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(int pageNumber = 0, bool isFull = false)
        //public async Task<IViewComponentResult> InvokeAsync(IList<PriceList> priceList, bool isFull = false)
        {
            if (!isFull)
                return View("PriceListTable", await _unitOfWork.PriceLists.GetPriceListByPageAsync(pageNumber));
            else
                return View("PriceListTable", await _unitOfWork.PriceLists.GetFullPriceListAsync());
                
        }
    }
}

