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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetPartOfAddress(IList<string> parameters)
        public async Task<List<string>> GetPartOfAddress(string parameter)
        {
            //if (!parameters.Any())
            if (string.IsNullOrWhiteSpace(parameter))
                return new List<string>{"Not found"};
            var result = await _partOfAddress.GetAddressPart(parameter);
            if (!result.Any())
                return new List<string>{"Not found"};
            return result.ToList();
        }
    }
}
