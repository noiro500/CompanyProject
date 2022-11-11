using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.Dto;
using CompanyProject.Domain.Message;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class MessageForm : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            MessageDto mes = new MessageDto();
            return Task.FromResult<IViewComponentResult>(View("MessageForm", mes));
        }
    }
}
