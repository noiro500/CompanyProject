using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class GetPartOfAddressVc : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPartOfAddressVc(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(IList<string> parameters)
        {
            if (parameters[0]== "District")
            {
                ViewBag.PartOfAddress = parameters[0];
                var districts = await _unitOfWork.AddressFromDbs.GetUsedDistrictsAsync();
                return View("GetPartOfAddressVc", districts);
            }

            else if (parameters[0] == "PopulatedArea")
            {
                ViewBag.PartOfAddress = parameters[0];
                var populatedArea = await _unitOfWork.AddressFromDbs.GetWorkPopulatedAreaAsync(parameters[1]);
                return View("GetPartOfAddressVc", populatedArea);
            }
            else return null;
            
        }
    }
}
