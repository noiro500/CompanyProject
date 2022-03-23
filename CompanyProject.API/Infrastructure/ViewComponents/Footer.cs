using System.Linq;
using System.Threading.Tasks;
using CompanyProject.Domain;
using CompanyProject.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class Footer : ViewComponent
    {
        //private IRepository<Page> repository;
        private readonly IUnitOfWork _unitOfWork;

        public Footer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Footer", await _unitOfWork.Pages.GetAllEntity().ToListAsync());
        }

    }
}
