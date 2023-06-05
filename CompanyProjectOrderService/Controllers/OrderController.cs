using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProjectOrderService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)=>_unitOfWork = unitOfWork ?? throw new AggregateException(nameof(unitOfWork));
    }
}
