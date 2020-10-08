﻿using System;
using CompanyProject.Domain;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class CompanyInfo : ViewComponent
    {
        //private readonly IRepository<CompanyContact> _companyContact;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyInfo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke(string info)
        {
            var companyInfo = _unitOfWork.CompanyContacts.GetToUseAsync("ToUse").Result;

            if (info.Equals("CompanyName", System.StringComparison.CurrentCultureIgnoreCase))
                return new HtmlContentViewComponentResult(new HtmlString(companyInfo.CompanyName));
            if (info.Equals("Address", System.StringComparison.CurrentCultureIgnoreCase))
                return Content(companyInfo.Address);
            if (info.Equals("PhoneNumber", System.StringComparison.CurrentCultureIgnoreCase))
                return Content(companyInfo.PhoneNumber);
            if (info.Equals("WhatsApp", System.StringComparison.CurrentCultureIgnoreCase))
                return Content(companyInfo.WhatsApp);
            if (info.Equals("WorkTime", StringComparison.CurrentCultureIgnoreCase))
                return Content(companyInfo.WorkTime);
            else return Content("Info not send");
        }
    }
}