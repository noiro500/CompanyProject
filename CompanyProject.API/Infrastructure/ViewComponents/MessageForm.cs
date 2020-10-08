using System.Threading.Tasks;
using CompanyProject.Domain.MessageAggregate;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class MessageForm : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            Message mes = new Message();
            return Task.FromResult<IViewComponentResult>(View("MessageForm", mes));
        }
    }
}
