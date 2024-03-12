using CompanyProjectAddressService.Infrastructure.PartOfAddress;
using EntityFrameworkCore.Repository.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace CompanyProjectAddressService.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    public class AddressController : ControllerBase
    {
       private readonly IPartOfAddress _partOfAddress;

        public AddressController(IPartOfAddress partOfAddress)=>_partOfAddress = partOfAddress ?? throw new ArgumentNullException(nameof(partOfAddress));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IList<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPartOfAddress(string parameter)
        {
            //if (!parameters.Any())
            if (string.IsNullOrWhiteSpace(parameter))
                return BadRequest();
            var result = await _partOfAddress.GetAddressPart(parameter);
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }
    }
}
