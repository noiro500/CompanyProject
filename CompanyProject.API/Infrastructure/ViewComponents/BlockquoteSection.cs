using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class BlockquoteSection : ViewComponent
    {
        public IViewComponentResult Invoke(string name)
        {
            return View("BlockquoteSection", name);
        }
    }
}
