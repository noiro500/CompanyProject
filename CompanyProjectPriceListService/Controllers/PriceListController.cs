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
    [Route("api/v1/[controller]")]
    public class PriceListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public PriceListController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new AggregateException(nameof(unitOfWork));

        [HttpGet("{pageName:regex(^\\w+$)}")]
        [ProducesResponseType(StatusCodes.Status200OK/*, Type = typeof(PriceList)*/)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string pageName="full")
        {
            var repository = _unitOfWork.Repository<PriceList>();
            List<PriceList>? result = new();
            if (pageName == "full")
            {
                var query = repository.MultipleResultQuery()
                    .OrderBy(x => x.PriceListId);
                result = await repository.SearchAsync(query) as List<PriceList>;
            }

            if (pageName == "typeoffailures")
            {
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
                    return Ok(resultTypeOfFailures);
                }
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
    }

}
