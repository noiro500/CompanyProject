using System.Threading.Tasks;
using CompanyProject.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            return View((await _unitOfWork.Pages.GetAsync(1)));
        }

        //[Route("computers-repair")]
        //public async Task<IActionResult> ComputersRepair()
        //{
        //    return View(await _repository.GetByIdAsync(2));
        //}
        //[Route("b2b")]
        //public async Task<IActionResult> B2b()
        //{
        //    return View(await _repository.GetByIdAsync(7));
        //}
        //[Route("data-recovery")]
        //public async Task<IActionResult> DataRecovery()
        //{
        //    return View(await _repository.GetByIdAsync(6));
        //}
        //[Route("help-desk")]
        //public async Task<IActionResult> HelpDesk()
        //{
        //    return View(await _repository.GetByIdAsync(4));
        //}
        //[Route("internet-networks")]
        //public async Task<IActionResult> InternetNetworks()
        //{
        //    return View(await _repository.GetByIdAsync(5));
        //}
        //[Route("laptops-repair")]
        //public async Task<IActionResult> LaptopsRepair()
        //{
        //    return View(await _repository.GetByIdAsync(3));
        //}
        //[Route("laptop-upgrade")]
        //public async Task<IActionResult> LaptopUpgrade()
        //{
        //    return View("LaptopsRepair", await _repository.GetByIdAsync(3));
        //}
        //[Route("pc-assembly")]
        //public async Task<IActionResult> PcAssembly()
        //{
        //    return View("ComputersRepair",await _repository.GetByIdAsync(2));
        //}
        //[Route("office-equipment")]
        //public async Task<IActionResult> OfficeEquipment()
        //{
        //    return View(await _repository.GetByIdAsync(10));
        //}
    }
}