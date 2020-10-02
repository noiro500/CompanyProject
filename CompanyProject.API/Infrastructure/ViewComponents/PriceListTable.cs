using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class PriceListTable:ViewComponent
    {
        private readonly IPriceListRepository repository;

        public PriceListTable(IPriceListRepository repo)
        {
            repository = repo;
        }

        public async Task <IViewComponentResult> InvokeAsync(int pageNumber)
        {
           return View("PriceListTable", await repository.GetPriceListByPageAsync(pageNumber));
        }
    }
}

