using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.ViewModels;
using CompanyProject.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
            var cardList = await (_unitOfWork.Pages.GetPagesForCards("ToCard"))
                    .Select(c => new CardViewModel(c.ScreenName.ToUpper(), c.AspController , c.Name, c.Name + ".png"))
                .ToListAsync();
            return View("Cards", cardList);
        }
    }
}
