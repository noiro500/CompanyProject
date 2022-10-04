﻿using CompanyProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.RefitInterfaces;

namespace CompanyProject.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentService _contentService;
        public HomeController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            var aaa=await _contentService.GetCompanyContactAsync(true);
            return View(resultAsync);
        }

        [Route("computers-repair")]
        public async Task<IActionResult> ComputersRepair()
        {
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            ViewBag.pageNameForPriceList = ViewBag.pageNameForCard;
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            return View(resultAsync);
        }

        [Route("laptops-repair")]
        public async Task<IActionResult> LaptopsRepair()
        {
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            ViewBag.pageNameForPriceList = ViewBag.pageNameForCard;
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            return View(resultAsync);
        }

        [Route("help-desk")]
        public async Task<IActionResult> HelpDesk()
        {
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            ViewBag.pageNameForPriceList = ViewBag.pageNameForCard;
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            return View(resultAsync);
        }

        [Route("internet-networks")]
        public async Task<IActionResult> InternetNetworks()
        {
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            ViewBag.pageNameForPriceList = ViewBag.pageNameForCard;
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            return View(resultAsync);
        }

        [Route("data-recovery")]
        public async Task<IActionResult> DataRecovery()
        {
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            ViewBag.pageNameForPriceList = ViewBag.pageNameForCard;
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            return View(resultAsync);
        }

        [Route("b2b")]
        public async Task<IActionResult> B2b()
        {
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            ViewBag.pageNameForPriceList = ViewBag.pageNameForCard;
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            return View(resultAsync);
        }

        [Route("laptop-upgrade")]
        public async Task<IActionResult> LaptopUpgrade()
        {
            //return View("LaptopsRepair", (await _unitOfWork.Pages.GetWithInclude(p => p.Paragraphs))
            //    .FirstOrDefault(t => t.PageId == 3));
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            ViewBag.pageNameForPriceList = "LaptopsRepair".ToLower();
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            return View(resultAsync);
        }

        [Route("pc-assembly")]
        public async Task<IActionResult> PcAssembly()
        {
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            ViewBag.pageNameForPriceList = "ComputersRepair".ToLower();
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            return View(resultAsync);
        }

        [Route("office-equipment")]
        public async Task<IActionResult> OfficeEquipment()
        {
            ViewBag.pageNameForCard = RouteData.Values["action"].ToString().ToLower();
            ViewBag.pageNameForPriceList = ViewBag.pageNameForCard;
            var resultAsync = await _contentService.GetPageContentAsync(RouteData.Values["action"].ToString());
            return View(resultAsync);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}