using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.Domain;
using CompanyProject.Domain.PriceList;
using CompanyProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class TypeOfFailureViewModel
    {
        public string Service {internal set; get; }
        public string ServiceName { internal set; get; }
    }
    public class TypeOfFailureVc:ViewComponent
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly CompanyProjectDbContext _context;

        public TypeOfFailureVc(CompanyProjectDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var typeOfFailure = await _context.Set<PriceList>()
                .Select(c => new TypeOfFailureViewModel { Service = c.Service, ServiceName = c.ServiceName}).ToListAsync();
            typeOfFailure.Add(item: new TypeOfFailureViewModel { Service="Прочее", ServiceName = "Прочее"});

            for (int i = 0; i < typeOfFailure.Count; i++)
            {
                var index = typeOfFailure[i].Service.IndexOf('(');
                if (index > 0)
                {
                    var strigForReplace = typeOfFailure[i].Service.Remove(index);
                    typeOfFailure[i].Service = strigForReplace;
                }
            }

            return View("TypeOfFailureVc", typeOfFailure);
        }

    }
}
