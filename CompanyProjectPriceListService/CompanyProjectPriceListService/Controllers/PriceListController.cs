using CompanyProjectPriceListService.Model;
using EntityFrameworkCore.QueryBuilder.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace CompanyProjectPriceListService.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PriceListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PriceListController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new AggregateException(nameof(unitOfWork));
        
        [HttpGet("{pageName:regex(^\\w+$)}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PriceList))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPriceListByPageAsync(string pageName)
        {
            var repository = _unitOfWork.Repository<PriceList>();
            List<PriceList>? resultList = new ();
            if (pageName == "helpdesk")
            {
                var queryComputersrepair = repository.MultipleResultQuery().AndFilter(p =>
                     p.PageName == "computersrepair".ToLower());
                var queryLaptopsrepair = repository.MultipleResultQuery().AndFilter(p =>
                    p.PageName == "laptopsrepair".ToLower());
                resultList.AddRange(await repository.SearchAsync(queryComputersrepair));
                resultList.AddRange(await repository.SearchAsync(queryLaptopsrepair));

            }
            else
            {
               var query = repository.MultipleResultQuery().AndFilter(p => p.PageName == pageName.ToLower());
               resultList.AddRange(await repository.SearchAsync(query));
            }
            if (resultList.Count==0)
                return NotFound();
            return Ok(resultList);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PriceList))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFullPriceListAsync()
        {
            var repository = _unitOfWork.Repository<PriceList>();
            var query = repository.MultipleResultQuery().OrderBy(x => x.PriceListId);
            var result = await repository.SearchAsync(query);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }

}
