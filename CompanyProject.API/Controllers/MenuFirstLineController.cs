using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Controllers
{
    public class MenuFirstLineController : Controller
    {
        public IActionResult Comments()
        {
            return View();
        }

        public IActionResult FullPriceList()
        {
            return View();
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
