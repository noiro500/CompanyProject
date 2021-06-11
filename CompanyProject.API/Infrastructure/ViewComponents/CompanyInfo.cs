using System;
using System.Threading.Tasks;
using CompanyProject.Domain;
using CompanyProject.Domain.CompanyContact;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class CompanyInfo : ViewComponent
    {
        //private readonly IRepository<CompanyContact> _companyContact;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CompanyContact _companyContacts;

        public CompanyInfo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _companyContacts = _unitOfWork.CompanyContacts.GetToUseCompany("ToUse");

        }
        public async Task<IViewComponentResult> InvokeAsync(string info)
        {
            //var companyInfo =(await _unitOfWork.CompanyContacts.GetToUseCompanyAsync("ToUse"));

            if (info.Equals("CompanyName", System.StringComparison.CurrentCultureIgnoreCase))
                return new HtmlContentViewComponentResult(new HtmlString(_companyContacts.CompanyName));
            if (info.Equals("Address", System.StringComparison.CurrentCultureIgnoreCase))
                return Content(_companyContacts.Address);
            if (info.Equals("PhoneNumber", System.StringComparison.CurrentCultureIgnoreCase))
                return Content(_companyContacts.PhoneNumber);
            if (info.Equals("WhatsApp", System.StringComparison.CurrentCultureIgnoreCase))
                return Content(_companyContacts.WhatsApp);
            if (info.Equals("WorkTime", StringComparison.CurrentCultureIgnoreCase))
                return Content(_companyContacts.WorkTime);
            //else return Content("Info not send");
            else return Content("Нет данных");
        }
    }
}
