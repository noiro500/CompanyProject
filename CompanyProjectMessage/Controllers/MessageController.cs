using CompanyProjectMessage.Model;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProjectMessage.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MessageController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;

        public MessageController(IUnitOfWork unitOfWork)=>_unitOfWork=unitOfWork??throw new AggregateException(nameof(unitOfWork));

        [HttpPost]
        public async Task<ActionResult<Message>> Post([FromBody] Message message)
        {
            var repository = _unitOfWork.Repository<Message>();
            var mes = repository.Add(message);
            await _unitOfWork.SaveChangesAsync();
            return Ok(message);
        }
    }
}