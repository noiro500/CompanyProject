using CompanyProject.Domain;
using CompanyProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using CompanyProject.Domain.Interfaces;
using CompanyProject.API.Infrastructure.Dto;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class TopMenu : ViewComponent
    {
        private readonly IContentService _contentService;

        public TopMenu(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var topMenuEntities = await _contentService.GetTopMenuEntitiesAsync();
            var topMenuFirstLine = topMenuEntities.Where(m => m.FirstLine==true).ToList();
            var topMenuNavBar = topMenuEntities.Where(m => m.NavBar == true).ToList();
            var topMenuDictionary = new Dictionary<string, List<TopMenuEntityDto>>();
            topMenuDictionary["firstLine"] = topMenuFirstLine;
            topMenuDictionary["topMenuNavBar"] = topMenuNavBar;
            return View("TopMenu", topMenuDictionary);
            
        }

    }
}
