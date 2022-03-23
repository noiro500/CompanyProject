using CompanyProject.Domain;
using CompanyProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.Domain.Interfaces;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class TopMenu : ViewComponent
    {
        // private readonly IRepository<Page> _context;
        private readonly IUnitOfWork _unitOfWork;

        public TopMenu(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var topMenuFirstLine = new List<TopMenuLineViewModel>
            {
                new TopMenuLineViewModel{
                    FirstLine =true,
                    AspAction ="Comments",
                    AspController = "MenuFirstLine",
                    Icon = "fas fa-star",
                    IconColor ="orange",
                    NavBar = false,
                    NeedStar = true,
                    ScreenName = "Отзывы"},
                new TopMenuLineViewModel{
                    FirstLine =true,
                    AspAction ="FullPriceList",
                    AspController = "MenuFirstLine",
                    Icon = "fas fa-ruble-sign",
                    IconColor ="gray",
                    NavBar = false,
                    NeedStar = false,
                    ScreenName = "Цены"},
                new TopMenuLineViewModel{
                    FirstLine =true,
                    NavBar = false,
                    NeedStar = false,
                    AspController = "MenuFirstLine",
                    AspAction ="About",
                    Icon = "fas fa-info",
                    IconColor ="gray",
                    ScreenName = "О Компании"},
                new TopMenuLineViewModel{
                    FirstLine =true,
                    NavBar = false,
                    NeedStar = false,
                    AspController = "MenuFirstLine",
                    AspAction ="Contacts",
                    Icon = "fas fa-map-marker-alt",
                    IconColor ="gray",
                    ScreenName = "Контакты"}
            };
            var navBar = await _unitOfWork.Pages.GetAllEntity().ToListAsync();
            var topMenuNavBar = new List<TopMenuLineViewModel>();
            foreach (var page in navBar)
            {
                if (page.Name == "Index")
                    continue;
                topMenuNavBar.Add(new TopMenuLineViewModel
                {
                    FirstLine = false,
                    NavBar = page.ToNavbar,
                    NeedStar = false,
                    AspController = "Home",
                    AspAction = page.Name,
                    Icon = page.Icon,
                    IconColor = "black",
                    ScreenName = page.ScreenName
                });
            }
            IDictionary<string, List<TopMenuLineViewModel>> topMenuDictionary = new Dictionary<string, List<TopMenuLineViewModel>>();
            topMenuDictionary["firstLine"] = topMenuFirstLine;
            topMenuDictionary["topMenuNavBar"] = topMenuNavBar;
            return View("TopMenu", topMenuDictionary);
        }

    }
}
