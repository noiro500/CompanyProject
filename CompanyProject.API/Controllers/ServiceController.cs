using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.ViewModels;
using CompanyProject.Domain;
using CompanyProject.Domain.Message;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpPost]
        public async Task<IActionResult> MakeOrder(OrderViewModel order)
        {
            return View();
        }

        public IActionResult MakeOrder()
        {
            return View();
        }

        public IActionResult MakeOrderConfirm(OrderViewModel order)
        {
            if (!order.IsAdoptedPrivacyPolicy)
                return Json(false);
            else
                return ViewComponent("MakeOrderCheckingData", order);
        }

        public IActionResult GetPartOfAddress(IList<string> parameters)
        {
            return ViewComponent("GetPartOfAddressVc", parameters);
            
        }

        

    }
}