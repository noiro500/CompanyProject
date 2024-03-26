using CompanyProjectPriceListService.Model;
using EntityFrameworkCore.QueryBuilder.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace CompanyProjectPriceListService.Controllers
{
    
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class PriceListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public PriceListController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new AggregateException(nameof(unitOfWork));

        [HttpGet("{pageName:regex(^\\w+$)}")]
        [ProducesResponseType(StatusCodes.Status200OK/*, Type = typeof(PriceList)*/)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPriceList(string pageName="full")
        {
            var repository = _unitOfWork.Repository<PriceList>();
            List<PriceList>? result = new();
            if (pageName == "full")
            {
                var query = repository.MultipleResultQuery()
                    .OrderBy(x => x.PriceListId);
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
                    result?.AddRange(await repository.SearchAsync(queryComputersrepair));
                    result?.AddRange(await repository.SearchAsync(queryLaptopsrepair));

                }
                else
                {
                    var query = repository.MultipleResultQuery().AndFilter(p => p.PageName == pageName.ToLower());
                    result.AddRange(await repository.SearchAsync(query));
                }
            }
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }

        public async Task<IActionResult> /*Task<IList<TypeOfFailure>>*/ GetListOfTypeOfFailure()
        {
            var repository = _unitOfWork.Repository<PriceList>();
            List<PriceList>? result = new();
            var query = repository.MultipleResultQuery().OrderBy(x => x.PriceListId)
                .Select(selector => new TypeOfFailure {Service = selector.Service, ServiceName = selector.ServiceName});
            var resultTypeOfFailures = await repository.SearchAsync(query) as List<TypeOfFailure>;
            if(!resultTypeOfFailures.Any())
                return NotFound();
            else
            {
                resultTypeOfFailures.ForEach(elem =>
                {
                    var index = elem.Service.IndexOf('(');
                    if (index > 0)
                    {
                        var stringForReplace = elem.Service.Remove(index);
                        elem.Service = stringForReplace.TrimEnd();
                    }
                });
                resultTypeOfFailures.Add(new TypeOfFailure {Service = "Прочее", ServiceName = "Прочее"});
IEnumerable<TypeOfFailure> ListTypeOfFailures=Enumerable.Range(1, resultTypeOfFailures.Count).Select(x=>new TypeOfFailure {Id = x, Service = resultTypeOfFailures[x - 1].Service, ServiceName = resultTypeOfFailures[x - 1].ServiceName });
                return Ok(ListTypeOfFailures);
            }
        }
    }

}
