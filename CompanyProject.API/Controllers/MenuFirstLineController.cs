using System.Linq;
using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.HelpClasses;
using CompanyProject.API.Infrastructure.Log;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using CompanyProject.Domain;
using CompanyProject.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CompanyProject.API.Controllers
{
    public class MenuFirstLineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IContentService _contentService;

        public MenuFirstLineController(IUnitOfWork unitOfWork, IContentService contentService)
        {
            _logger = Log.CreateLogger<HomeController>();
            _unitOfWork = unitOfWork;
            _contentService = contentService;
        }
        [Route("/comments")]
        public IActionResult Comments()
        {
            return View();
        }

        /// <summary>
        /// Возвращает fullpricelist из микросервиса CompanyProjectPriceListService
        /// </summary>
        /// <returns>Спикок PriceListDto</returns>
        [Route("/fullpricelist")]
        public async Task<IActionResult> FullPriceList()
        {
            var result =  (await _contentService.GetFullPriceListAsync()).OrderBy(p=>p.PriceListId).Distinct(new PriceListDtoComparer()).ToList();
            return View(result);
        }

        [Route("/about")]
        public async Task<IActionResult> About()
        {
            var companyInfo = await _unitOfWork.CompanyContacts.GetToUseCompanyAsync("ToUse");
            return View("About", companyInfo);
        }

        [Route("/contacts")]
        public async Task<IActionResult> Contacts()
        {
            var companyInfo = await _unitOfWork.CompanyContacts.GetToUseCompanyAsync("ToUse");
            return View("Contacts", companyInfo);
        }
    }
}
