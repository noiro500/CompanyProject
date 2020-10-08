using System.Threading.Tasks;
using CompanyProject.Domain;
using CompanyProject.Domain.MessageAggregate;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Controllers
{
    public class ServiceController : Controller
    {
        /*private readonly IMessageRepository _message;*/
        //private readonly IOrderRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Ajax send form
        [HttpPost]
        public async Task<IActionResult> AddMessageToDbAsyncTask(Message mes)
        {
            if(!mes.IsAdoptedPrivacyPolicy)
            {
                return Json("false");
            }
            else
            {
                //await _message.AddMessageAsync(mes);
                await _unitOfWork.Messages.AddAsync(mes);
                await _unitOfWork.Complete();
                return Json("true");
            }
        }
        //[Route("PrivacyPolicy")]
        //public VirtualFileResult GetConfidentialFileResult()
        //{
        //    var filepath = Path.Combine("~/Resources/Files", "Политика конфиденциальности.pdf");
        //    return File(filepath, "application/pdf", "Политика конфиденциальности.pdf");
        //}

        //[HttpPost]
        //public async Task<IActionResult> MakeOrder(Order order)
        //{
        //    await _repository.AddOrder(order);
        //    return RedirectToAction("MakeOrderOk");
        //}

        //[HttpGet]
        //public Task<IActionResult> MakeOrderOk()
        //{
        //    return Task.FromResult<IActionResult>(View());
        //}
        //[HttpGet]
        //public Task<IActionResult> MakeOrder()
        //{
        //    return Task.FromResult<IActionResult>(View());
        //}
    }
}