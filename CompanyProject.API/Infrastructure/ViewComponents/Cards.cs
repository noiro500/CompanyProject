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
        //private readonly IRepository<Page> _context;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IContentService _contentService;

        public Cards(IContentService contentService)
        {
            _contentService= contentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string pageNameForCard)
        {
            var cardList = await _contentService.GetCards(pageNameForCard);
            return View("Cards", cardList);
        }
    }
}
