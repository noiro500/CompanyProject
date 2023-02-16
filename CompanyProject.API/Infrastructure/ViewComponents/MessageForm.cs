using CompanyProject.API.Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;
//using CompanyProject.Domain.Message;

namespace CompanyProject.API.Infrastructure.ViewComponents;

public class MessageForm : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var mes = new MessageDto();
        return View("MessageForm", mes);
    }
}