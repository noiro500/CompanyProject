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
            ViewBag.PartOfAddress = parameters[0];
            if (parameters[0]== "District")
            {
                var districtsList = await _unitOfWork.AddressFromDbs.GetUsedDistrictsAsync();
                return View("GetPartOfAddressVc", districtsList);
            }

            else if (parameters[0] == "PopulatedArea")
            {
                var populatedAreaList = await _unitOfWork.AddressFromDbs.GetWorkPopulatedAreaAsync(parameters[1]);
                return View("GetPartOfAddressVc", populatedAreaList);
            }
            else if (parameters[0] == "Street")
            {
                var strretList = await _unitOfWork.AddressFromDbs.GetWorkStreetAsync(parameters[1]);
                return View("GetPartOfAddressVc", strretList);
            }
            else throw new Exception();
            
        }
    }
}
