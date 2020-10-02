using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class Footer : ViewComponent
    {
        private IRepository<Page> repository;

        public Footer(IRepository<Page> repo)
        {
            repository = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //return Task.FromResult<IViewComponentResult>(View("Footer", repository.GetAllPages().OrderBy(i => i.PageId)));
            return View("Footer", (await repository.GetAllAsync()).OrderBy(i => i.PageId));

        }

    }
}
