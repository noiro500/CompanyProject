using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class TopMenu : ViewComponent
    {
        private readonly IRepository<Page> _context;

        public TopMenu(IRepository<Page> ctx)
        {
            _context = ctx;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var topMenuFirstLine = new List<TopMenuLine>
            {
                new TopMenuLine(
                    true, false,  true,
                    "Menu", "Comments", "fas fa-star",
                    "orange", "Отзывы"),
                new TopMenuLine(
                    true, false, false,
                    "Menu", "PriceList","fas fa-ruble-sign",
                    "gray", "Цены"),
                new TopMenuLine(
                    true, false, false,
                    "Menu", "About","fas fa-info",
                    "gray", "О Компании"),
                new TopMenuLine(
                    true, false, false,
                    "Menu", "Contact", "fas fa-map-marker-alt",
                    "gray", "Контакты")
            };
            var navBar = await _context.GetAllAsync();
            var topMenuNavBar=new List<TopMenuLine>();
            foreach (var page in navBar)
            {
                if (page.Name == "Index")
                    continue;
                topMenuNavBar.Add(new TopMenuLine(
                    false, page.ToNavbar, false, "Home",
                    page.Name, page.Icon, "black", page.ScreenName
                    ));
            }
            //navBar.AsParallel().ForAll(page =>
            //{
            //    if (page.Name != "Index")
            //        topMenuNavBar.Add(new TopMenuLine(
            //        false, page.ToNavbar, false, "Home",
            //        page.Name, page.Icon, "black", page.ScreenName
            //        ));
            //});
            IDictionary<string, List<TopMenuLine>> topMenuDictionary=new Dictionary<string, List<TopMenuLine>>();
            topMenuDictionary["firstLine"] = topMenuFirstLine;
            topMenuDictionary["topMenuNavBar"] = topMenuNavBar;
            //return Task.FromResult<IViewComponentResult>(View("TopMenu", context.GetAllPages()));
            return View("TopMenu", topMenuDictionary);
        } 

    }
}
