using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class MakeOrderCheckingData:ViewComponent
    {
        public IViewComponentResult Invoke(OrderViewModel order)
        {
            return View("MakeOrderCheckingData", order);
        }
    }
}
