using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using CompanyProject.ViewModels;
using CompanyProject.Domain;
using CompanyProject.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;


namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class Cards: ViewComponent
    {
        private readonly IContentServiceCard _contentServiceCard;

        public Cards(IContentServiceCard contentService)
        {
            _contentServiceCard= contentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string pageNameForCard)
        {
            var cardList = await _contentServiceCard.Get(pageNameForCard);
            return View("Cards", cardList);
        }
    }
}
