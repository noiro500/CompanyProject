using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
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
        public IActionResult MakeOrderConfirmResult(IDictionary<string, string> orderViewModel)
        {
            return PartialView("ContentViews/PartialView/MakeOrderConfirmResult");
        }

        public IActionResult MakeOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeOrderConfirm(OrderViewModel order)
        {
            if (order != null)
            {
                var orderProperties = order.GetType().GetProperties();
                ViewBag.orderPropLength = orderProperties.Length;
                var dictionaryAttributes = new Dictionary<string, string>();
                foreach (var propertyInfo in orderProperties)
                {
                    if (propertyInfo.GetValue(order) == null)
                    {
                        propertyInfo.SetValue(order, "Отсутствует");
                    }
                    
                    if (propertyInfo.GetCustomAttribute<DisplayAttribute>()!= null)
                        dictionaryAttributes.Add(propertyInfo.GetCustomAttribute<DisplayAttribute>().Name, propertyInfo.GetValue(order).ToString());
                }
                return PartialView("ContentViews/PartialView/MakeOrderConfirm", dictionaryAttributes);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> GetPartOfAddress(IList<string> parameters)
        {
            ViewBag.PartOfAddress = parameters[0];
            if (parameters[0] == "District")
            {
                var districtsList = (await _unitOfWork.AddressFromDbs.GetUsedDistrictsAsync());
                return PartialView("ContentViews/PartialView/GetPartOfAddress", districtsList);
            }

            else if (parameters[0] == "PopulatedArea")
            {
                var populatedAreaList = (await _unitOfWork.AddressFromDbs.GetWorkPopulatedAreaAsync(parameters[1])).AsEnumerable();
                return PartialView("ContentViews/PartialView/GetPartOfAddress", populatedAreaList);
            }
            else if (parameters[0] == "Street")
            {
                var strretList = (await _unitOfWork.AddressFromDbs.GetWorkStreetAsync(parameters[1])).AsEnumerable();
                return PartialView("ContentViews/PartialView/GetPartOfAddress", strretList);
            }
            else throw new Exception();

        }

        

    }
}