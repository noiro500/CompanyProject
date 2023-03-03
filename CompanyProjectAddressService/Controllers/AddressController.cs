using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using CompanyProjectAddressService.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectAddressService.Controllers
{
   [Route("api/v1/[controller]/[action]")]
    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public AddressController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPartOfAddress(IList<string> parameters)
        {
            if(!parameters.Any())
                return NotFound();
            if (parameters[0] == "District")
            {
                var repository = _unitOfWork.Repository<AddressInDb>();
                var query = repository.MultipleResultQuery()
                    .AndFilter(p => p.IsUsedInDistrict == true)
                    .OrderBy(p => p.Offname)
                    .Select(m => m.Offname);
                var result = await repository.SearchAsync(query);
                if (result is null)
                    return NotFound();
                HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return Ok(result);
            }

            return NotFound();
        }
    }
}
