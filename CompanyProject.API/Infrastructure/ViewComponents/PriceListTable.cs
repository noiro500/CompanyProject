﻿using System;
using System.Threading.Tasks;
using CompanyProject.Domain;
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

        public async Task<IViewComponentResult> InvokeAsync(int? pageNumber, bool isFull = false)
        {
            if (!isFull)
                return View("PriceListTable", await _unitOfWork.PriceLists.GetPriceListByPageAsync(pageNumber.Value));
            else
                return View("PriceListTable", await _unitOfWork.PriceLists.GetFullPriceListAsync());
                
        }
    }
}

