using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.HelpClasses;
using CompanyProject.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace CompanyProject.API.Controllers
{
    public class MenuFirstLineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuFirstLineController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Comments()
        {
            return View();
        }

        [Route("/fullpricelist")]
        public async Task<IActionResult> FullPriceList()
        {
            var result =(await _unitOfWork.PriceLists.GetAll().OrderBy(p=>p.PriceListId).ToListAsync()).Distinct(new PriceListComparer()).ToList();
            return View(result);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
    }
}
