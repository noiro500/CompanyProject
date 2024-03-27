using CompanyProjectAddressService.Infrastructure.PartOfAddress;
using CompanyProjectAddressService.Model;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPartOfAddress(string ident,string selectedParam="")
        {
            if (string.IsNullOrWhiteSpace(ident))
                return BadRequest();
            var result = await _partOfAddress.GetAddressPart(ident, selectedParam);
            if (!result.Any())
                return NotFound();
            return Ok(Enumerable.Range(1, result.Count).Select(x=>new {Id = x, Name = result[x-1]}));
        }
    }
}
