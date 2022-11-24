using System.Security.Cryptography;
using System.Text.Json;
using CompanyProjectMessage.Model;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using EntityFrameworkCore.Repository.Interfaces;

namespace CompanyProjectMessage.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MessageController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        
        public MessageController(IUnitOfWork unitOfWork)=>_unitOfWork = unitOfWork ?? throw new AggregateException(nameof(unitOfWork));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dictionary<string, string> data)
        {
            var repository = _unitOfWork.Repository<Message>();
            
            foreach (var mes in data)
            {
                
                var sha512 = SHA512.Create();
                var resultShaHash = sha512.ComputeHash(Encoding.Unicode.GetBytes(mes.Value));
                var shaToText = Encoding.Unicode.GetString(resultShaHash);

                if (shaToText.SequenceEqual(mes.Key))
                {
                    var message = JsonSerializer.Deserialize<Message>(mes.Value);
                    if (message is null)
                        return BadRequest();
                    SetGuidAndNumberMessage(ref message, ref repository);
                    _ = repository.Add(message);
                    await _unitOfWork.SaveChangesAsync();
                    return Ok(message);
                }
            }
            return BadRequest();
        }

        private void SetGuidAndNumberMessage(ref Message mes, ref IRepository<Message> repository)
        {
            var mesGuid = Guid.NewGuid();
            var query = repository.SingleResultQuery()
                .AndFilter(guid => guid.MessageId == mesGuid);
            var guidResult = repository.SingleOrDefault(query);
            if (guidResult is not null)
                SetGuidAndNumberMessage(ref mes, ref repository);
            else
                mes.MessageId = mesGuid;
            var mesCount = Convert.ToBoolean(repository.Count(m => m.MessageNumber > 0));
            if (!mesCount)
            {
                mes.MessageNumber = 1;
                return;
            }
            mes.MessageNumber = (repository.Max(maxNum => maxNum.MessageNumber))+1;
        }
    }
}