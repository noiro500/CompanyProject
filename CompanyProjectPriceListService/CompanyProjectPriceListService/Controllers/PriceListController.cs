using CompanyProjectPriceListService.Model;
using EntityFrameworkCore.QueryBuilder.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace CompanyProjectPriceListService.Controllers
{
    //[Route("api/v1/[controller]/[action]")]
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PriceListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PriceListController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new AggregateException(nameof(unitOfWork));

        [HttpGet("{pageName:regex(^\\w+$)}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PriceList))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string pageName="full")
        {
            var repository = _unitOfWork.Repository<PriceList>();
            List<PriceList>? result = new();
            if (pageName == "full")
            {
                var query = repository.MultipleResultQuery().OrderBy(x => x.PriceListId);
                result = await repository.SearchAsync(query) as List<PriceList>;
                
            }
            else
            {
                if (pageName == "helpdesk")
                {
                    var queryComputersrepair = repository.MultipleResultQuery().AndFilter(p =>
                        p.PageName == "computersrepair".ToLower());
                    var queryLaptopsrepair = repository.MultipleResultQuery().AndFilter(p =>
                        p.PageName == "laptopsrepair".ToLower());
                    result.AddRange(await repository.SearchAsync(queryComputersrepair));
                    result.AddRange(await repository.SearchAsync(queryLaptopsrepair));

                }
                else
                {
                    var query = repository.MultipleResultQuery().AndFilter(p => p.PageName == pageName.ToLower());
                    result.AddRange(await repository.SearchAsync(query));
                }
            }
            if (result.Count==0)
                return NotFound();
            return Ok(result);
        }
    }

}
