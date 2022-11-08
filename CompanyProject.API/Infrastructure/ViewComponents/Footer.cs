using System.Linq;
using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using CompanyProject.Domain;
using CompanyProject.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class Footer : ViewComponent
    {
        private readonly IContentServiceContent _contentServiceContent;

        public Footer(IContentServiceContent contentService)
        {
            _contentServiceContent = contentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerListContent = await _contentServiceContent.GetFooterContentAsync();
            return View("Footer", footerListContent);
        }

    }
}
