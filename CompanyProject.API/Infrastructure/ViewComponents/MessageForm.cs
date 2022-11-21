using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.Dto;
//using CompanyProject.Domain.Message;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class MessageForm : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            MessageDto mes = new MessageDto();
            return View("MessageForm", mes);
        }
    }
}
