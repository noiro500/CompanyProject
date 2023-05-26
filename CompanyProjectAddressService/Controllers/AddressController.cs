using CompanyProjectAddressService.Infrastructure.PartOfAddress;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CompanyProjectAddressService.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    public class AddressController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IPartOfAddress _partOfAddress;

        public AddressController(/*IUnitOfWork unitOfWork,*/ IPartOfAddress partOfAddress)
        {
            //_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _partOfAddress = partOfAddress;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPartOfAddress(IList<string> parameters)
        {
            if (!parameters.Any())
                return NotFound();
            var result = await _partOfAddress.GetAddressPart(parameters);
            if (result is null)
                return NotFound();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return new ContentResult
            {
                Content = _partOfAddress.HtmlPart(parameters[0], result),
                ContentType = "text/html",
                StatusCode = 200
            };
        }
    }
}
