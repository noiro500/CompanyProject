using System.Linq;
using System.Threading.Tasks;
using CompanyProject.Domain;
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

        public IViewComponentResult Invoke()
        {
            //return Task.FromResult<IViewComponentResult>(View("Footer", repository.GetAllPages().OrderBy(i => i.PageId)));
            return View("Footer", _unitOfWork.Pages.GetAll());

        }

    }
}
