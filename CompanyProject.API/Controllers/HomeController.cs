using CompanyProject.API.Infrastructure.Log;
using CompanyProject.Domain;
using CompanyProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.Domain.Interfaces;

namespace CompanyProject.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _logger = Log.CreateLogger<HomeController>();
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            return View((await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 1));
        }

        [Route("computers-repair")]
        public async Task<IActionResult> ComputersRepair()
        {
            return View((await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 2));
        }

        [Route("laptops-repair")]
        public async Task<IActionResult> LaptopsRepair()
        {
            return View((await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 3));
        }

        [Route("help-desk")]
        public async Task<IActionResult> HelpDesk()
        {
            return View((await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 4));
        }

        [Route("internet-networks")]
        public async Task<IActionResult> InternetNetworks()
        {
            return View((await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 5));
        }

        [Route("data-recovery")]
        public async Task<IActionResult> DataRecovery()
        {
            return View((await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 6));
        }

        [Route("b2b")]
        public async Task<IActionResult> B2b()
        {
            return View((await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 7));
        }

        [Route("laptop-upgrade")]
        public async Task<IActionResult> LaptopUpgrade()
        {
            return View("LaptopsRepair", (await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 3));
        }

        [Route("pc-assembly")]
        public async Task<IActionResult> PcAssembly()
        {
            return View("ComputersRepair", (await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 2));
        }

        [Route("office-equipment")]
        public async Task<IActionResult> OfficeEquipment()
        {
            return View((await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
                .FirstOrDefault(t => t.PageId == 10));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}