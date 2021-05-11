﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.ViewModels;
using CompanyProject.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                new TopMenuLineViewModel(
                    true, false,  true,
                    "MenuFirstLine", "Comments", "fas fa-star",
                    "orange", "Отзывы"),
                new TopMenuLineViewModel(
                    true, false, false,
                    "MenuFirstLine", "FullPriceList","fas fa-ruble-sign",
                    "gray", "Цены"),
                new TopMenuLineViewModel(
                    true, false, false,
                    "MenuFirstLine", "About","fas fa-info",
                    "gray", "О Компании"),
                new TopMenuLineViewModel(
                    true, false, false,
                    "MenuFirstLine", "Contacts", "fas fa-map-marker-alt",
                    "gray", "Контакты")
            };
            var navBar = await _unitOfWork.Pages.GetAllEntity().ToListAsync();
            var topMenuNavBar=new List<TopMenuLineViewModel>();
            foreach (var page in navBar)
            {
                if (page.Name == "Index")
                    continue;
                topMenuNavBar.Add(new TopMenuLineViewModel(
                    false, page.ToNavbar, false, "Home",
                    page.Name, page.Icon, "black", page.ScreenName
                    ));
            }
            IDictionary<string, List<TopMenuLineViewModel>> topMenuDictionary=new Dictionary<string, List<TopMenuLineViewModel>>();
            topMenuDictionary["firstLine"] = topMenuFirstLine;
            topMenuDictionary["topMenuNavBar"] = topMenuNavBar;
            return View("TopMenu", topMenuDictionary);
        } 

    }
}
