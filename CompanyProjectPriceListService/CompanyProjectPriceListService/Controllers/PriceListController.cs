using CompanyProjectPriceListService.Model;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProjectPriceListService.Controllers
{
    [Route("api/v1/[controller]")]
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
            var query = repository.MultipleResultQuery().AndFilter(p => p.PageName == pageName.ToLower()).
                    Select(sel => new
                    {
                        sel.ServiceName,
                        sel.PageName,
                        sel.IdServiceName,
                        sel.Service,
                        sel.NeedWorks,
                        sel.ServicePrice
                    });
            var result = await repository.SearchAsync(query);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PriceList))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFullPriceListAsync()
        {
            var repository = _unitOfWork.Repository<PriceList>();
            var query = repository.MultipleResultQuery().
                Select(sel => new
                {
                    sel.ServiceName,
                    sel.PageName,
                    sel.IdServiceName,
                    sel.Service,
                    sel.NeedWorks,
                    sel.ServicePrice
                });
            var result = await repository.SearchAsync(query);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }

}
