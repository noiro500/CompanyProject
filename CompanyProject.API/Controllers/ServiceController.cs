﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using AutoMapper;
using CompanyProject.API.Infrastructure.Dto;
using CompanyProject.API.Infrastructure.Log;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Controllers;

public class ServiceController : Controller
{
    //private readonly IValidator<MessageDto> _validator;
    private readonly IContentServiceMessage _contentServiceMessage;

    private readonly ILogger _logger;

    //private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public ServiceController( /*IUnitOfWork unitOfWork,*/ IMapper mapper,
        IContentServiceMessage contentServiceMessage /*IValidator<MessageDto> validator*/)
    {
        _logger = Log.CreateLogger<HomeController>();
        //_unitOfWork = unitOfWork;
        _mapper = mapper;
        //_validator = validator;
        _contentServiceMessage = contentServiceMessage;
    }

    //Ajax send form
    [HttpPost]
    //[FormValidator]
    public async Task<IActionResult> AddMessageToDbAsyncTask(MessageDto mes)
    {
        if (!ModelState.IsValid) 
            return Json(JsonSerializer.Serialize(new {parameter = "error"}));
        if (!mes.IsAdoptedPrivacyPolicy)
        {
            return Json(JsonSerializer.Serialize(new {parameter = "warning"}));
        }

        var sha512 = SHA512.Create();
        var resultShaHash = sha512.ComputeHash(Encoding.Unicode.GetBytes(JsonSerializer.Serialize(mes)));
        var shaToText = Encoding.Unicode.GetString(resultShaHash);
        var dic = new Dictionary<string, string> {{shaToText, JsonSerializer.Serialize(mes)}};
        var response = await _contentServiceMessage.Post(dic);
        if (!response.IsSuccessStatusCode)
            return Json(JsonSerializer.Serialize(new {parameter = "error"}));
        return Json(JsonSerializer.Serialize(new {parameter = "ok"}));
    }

    //[HttpPost]
    //public async Task<IActionResult> MakeOrderConfirmResult()
    //{
    //    try
    //    {
    //        if (TempData.ContainsKey("orderViewModel"))
    //        {
    //            var isNewCustomer = true;
    //            var orderViewModel =
    //                JsonSerializer.Deserialize<OrderViewModel>((TempData["orderViewModel"] as string));
    //            var customer = (await _unitOfWork.Customers.GetWithInclude(p => p.Orders))
    //                .FirstOrDefault(p => p.PhoneNumber == orderViewModel.PhoneNumber);
    //            if (customer == null)
    //            {
    //                customer = _mapper.Map<Customer>(orderViewModel);
    //                await _unitOfWork.Customers.AddEntityAsync(customer);
    //            }
    //            else
    //                isNewCustomer = false;
    //            var order = _mapper.Map<Order>(orderViewModel);
    //            order.CreateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
    //            if (!isNewCustomer)
    //                _unitOfWork.Customers.UpdateEntity(customer);
    //            var onePrice = await _unitOfWork.PriceLists.GetAllEntity()
    //                .FirstOrDefaultAsync(p => p.Service == order.TypeOfFailure
    //                    .Substring(order.TypeOfFailure.IndexOf("- "))
    //                    .Remove(0, 2));
    //            string minPrice = (onePrice == null)
    //                ? "Стоимость будет определена после диагностики"
    //                : onePrice.ServicePrice;
    //            order.Price = decimal.TryParse(minPrice, out var price)
    //                ? price
    //                : 0;
    //            var lastOrderNumber = await _unitOfWork.Orders.GetAllEntity().MaxAsync(p=>p.OrderNumber);
    //            order.OrderNumber = ++lastOrderNumber ?? 1;
    //            customer.Orders.Add(order);
    //            await _unitOfWork.CompleteAsync();
    //            var makeOrderResultDic = new Dictionary<string, string>()
    //            {
    //                {"Ваш номер заказа:", order.OrderNumber.ToString()},
    //                {"Причина вызова мастера:", order.TypeOfFailure},
    //                {"Время прихода мастера:", order.VisitTime},
    //                {"Минимальная (ориентировочная) стоимость:", minPrice}
    //            };
    //            return PartialView("ContentViews/PartialView/_MakeOrderResult", makeOrderResultDic);

    //        }
    //        else
    //            return StatusCode(405);
    //    }
    //    catch (Exception)
    //    {
    //        _unitOfWork.Dispose();
    //        return StatusCode(405);
    //    }
    //}

    public IActionResult MakeOrder()
    {
        var orderViewModelDto = new OrderViewModelDto();
        return View(orderViewModelDto);
    }

    //[HttpPost]
    //public IActionResult MakeOrderConfirm(OrderViewModel order)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        if (order != null)
    //        {
    //            var orderProperties = order.GetType().GetProperties();
    //            var dictionaryAttributes = new Dictionary<string, string>();
    //            foreach (var propertyInfo in orderProperties)
    //            {
    //                if (propertyInfo.GetValue(order) == null) propertyInfo.SetValue(order, "Отсутствует");

    //                if (propertyInfo.GetCustomAttribute<DisplayAttribute>() != null)
    //                    dictionaryAttributes.Add(propertyInfo.GetCustomAttribute<DisplayAttribute>().Name,
    //                        propertyInfo.GetValue(order).ToString());
    //            }

    //            var options = new JsonSerializerOptions
    //            {
    //                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
    //                WriteIndented = true
    //            };
    //            TempData["orderViewModel"] = JsonSerializer.Serialize(order, options);
    //            return PartialView("ContentViews/PartialView/_MakeOrderConfirm", dictionaryAttributes);
    //        }

    //        return NotFound();
    //    }

    //    return View("Error");
    //}


    //[HttpPost]
    //public async Task<IActionResult> GetPartOfAddress(IList<string> parameters)
    //{
    //    ViewBag.PartOfAddress = parameters[0];
    //    if (parameters[0] == "District")
    //    {
    //        var districtsList = (await _unitOfWork.AddressFromDbs.GetUsedDistrictsAsync());
    //        return PartialView("ContentViews/PartialView/_GetPartOfAddress", districtsList);
    //    }

    //    else if (parameters[0] == "PopulatedArea")
    //    {
    //        var populatedAreaList = (await _unitOfWork.AddressFromDbs.GetWorkPopulatedAreaAsync(parameters[1])).AsEnumerable();
    //        return PartialView("ContentViews/PartialView/_GetPartOfAddress", populatedAreaList);
    //    }
    //    else if (parameters[0] == "Street")
    //    {
    //        var strretList = (await _unitOfWork.AddressFromDbs.GetWorkStreetAsync(parameters[1])).AsEnumerable();
    //        return PartialView("ContentViews/PartialView/_GetPartOfAddress", strretList);
    //    }
    //    else
    //        return BadRequest();
    //}
}