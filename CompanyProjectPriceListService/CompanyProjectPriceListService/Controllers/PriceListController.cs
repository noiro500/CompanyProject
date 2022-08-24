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
    }
}
