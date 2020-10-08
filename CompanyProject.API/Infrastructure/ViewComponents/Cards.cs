using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.API.ViewModels;
using CompanyProject.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class Cards: ViewComponent
    {
        //private readonly IRepository<Page> _context;
        private readonly IUnitOfWork _unitOfWork;

        public Cards(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pages = await (_unitOfWork.Pages.GetPagesForCards("ToCard")).ToListAsync();
            var cardList = new List<CardViewModel>();
            foreach (var card in pages)
            {
                cardList.Add(
                    new CardViewModel(card.ScreenName.ToUpper(), "Home", card.Name, card.Name + ".png")
                    );
            }
            return View("Cards", cardList);
        }
    }
}
