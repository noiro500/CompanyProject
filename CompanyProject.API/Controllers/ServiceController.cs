﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using CompanyProject.ViewModels;
using CompanyProject.Domain;
using CompanyProject.Domain.Customer;
using CompanyProject.Domain.Message;
using CompanyProject.Domain.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;

namespace CompanyProject.API.Controllers
{
    public class ServiceController : Controller
    {
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
                await _unitOfWork.Messages.AddEntityAsync(mes);
                await _unitOfWork.Complete();
                return Json("true");
            }
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrderConfirmResult()
        {
            if (TempData.ContainsKey("orderViewModel"))
            {
                var isNewCustomer = true;
                var orderViewModel = JsonSerializer.Deserialize<OrderViewModel>((TempData["orderViewModel"] as string));
                var customer = (await _unitOfWork.Customers.GetWithInclude(p => p.Orders))
                    .FirstOrDefault(p=>p.PhoneNumber== orderViewModel.PhoneNumber);
                if (customer == null)
                {
                    customer = new Customer
                    {
                        CustomerId = 0,
                        CustomerName = orderViewModel.CustomerName,
                        PhoneNumber = orderViewModel.PhoneNumber,
                        AnotherPhoneNumber = orderViewModel.AnotherPhoneNumber,
                        Email = orderViewModel.Email,
                        IsAdoptedPrivacyPolicy = orderViewModel.IsAdoptedPrivacyPolicy
                    };
                    await _unitOfWork.Customers.AddEntityAsync(customer);
                }
                else
                    isNewCustomer = false;
                var order = new Order(
                    0, orderViewModel.TypeOfFailure, orderViewModel.Description, orderViewModel.VisitTime,
                    orderViewModel.SpecialInstruction,
                    new Address
                    {

                        Territory = orderViewModel.Territory,
                        District = orderViewModel.District,
                        PopulatedArea = orderViewModel.PopulatedArea,
                        Street = orderViewModel.Street,
                        HouseNumber = orderViewModel.HouseNumber,
                        ApartmentOrOfficeNumber = orderViewModel.ApartmentOrOfficeNumber
                    },
                    false, 0, 0
                );
                if(!isNewCustomer)
                    customer.Orders.Add(order);
                _unitOfWork.Customers.UpdateEntity(customer);
                await _unitOfWork.Complete();
                return PartialView("ContentViews/PartialView/MakeOrderResult");

            }
            else
                return PartialView("ContentViews/PartialView/MakeOrderResult");
        }

        public IActionResult MakeOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeOrderConfirm(OrderViewModel order)
        {
            if (ModelState.IsValid)
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

                        if (propertyInfo.GetCustomAttribute<DisplayAttribute>() != null)
                            dictionaryAttributes.Add(propertyInfo.GetCustomAttribute<DisplayAttribute>().Name,
                                propertyInfo.GetValue(order).ToString());
                    }

                    var options = new JsonSerializerOptions
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                        WriteIndented = true
                    };
                    TempData["orderViewModel"] = JsonSerializer.Serialize(order, options);
                    ;
                    return PartialView("ContentViews/PartialView/MakeOrderConfirmPartial", dictionaryAttributes);
                }
                else
                    return NotFound();
            }

            return View("Error");
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