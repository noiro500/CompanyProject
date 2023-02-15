using CompanyProject.API.Infrastructure.Dto;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    //public class TypeOfFailureViewModel
    //{
    //    public string Service {internal set; get; }
    //    public string ServiceName { internal set; get; }
    //}

    public class TypeOfFailure:ViewComponent
    {
        //private readonly CompanyProjectDbContext _context;
        private readonly IContentServicePriceList _contentServicePriceList;

        public TypeOfFailure(IContentServicePriceList contentService)
        {
            _contentServicePriceList = contentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _contentServicePriceList.Get("typeoffailures") as List<TypeOfFailureDto>;
            return View("TypeOfFailure", result);
        }

    }
}
