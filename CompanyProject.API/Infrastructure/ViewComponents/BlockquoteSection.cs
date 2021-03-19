using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class BlockquoteSection : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string name)
        {
            return Task.FromResult<IViewComponentResult>(View("BlockquoteSection", name));
        }
    }
}
